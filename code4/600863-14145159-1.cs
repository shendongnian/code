    class Program {
        class MyException : Exception {}
        // A class for give the starting thread operation some parameters
        class ThreadStartParameter {
            // For identifying each thread
            public int Id { get; set; }
            // For building up a deeper callstack frame
            public int CallStackDepth { get; set; }
            // Indicates that this thread should throw an exception
            public bool ThrowException { get; set; }
        }
        static void Main(string[] args) {
            // Create two threads and let them run concurrently
            Thread t0 = new Thread(BuildUpCallStack) { Name = "Thread-0" };
            Thread t1 = new Thread(BuildUpCallStack) { Name = "Thread-1" };
            t0.Start(new ThreadStartParameter {
                Id = 0,
                CallStackDepth = 0,
                ThrowException = false
            });
            t1.Start(new ThreadStartParameter {
                Id = 1,
                CallStackDepth = 0,
                ThrowException = true
            });
            Console.Read();
        }
        // Recursive helper method to build a callstack of 30 frames, which
        // is used to rethrow an exception at each level
        static void BuildUpCallStack(object data) {
            ThreadStartParameter parameter = (ThreadStartParameter)data;
            if (parameter.CallStackDepth < 30) {
                try {
                    BuildUpCallStack(new ThreadStartParameter {
                        Id = parameter.Id,
                        CallStackDepth = parameter.CallStackDepth + 1,
                        ThrowException = parameter.ThrowException
                    });
                } catch (MyException e) {
                    Log(string.Format("Caught exception callstack frame {0}",
                        parameter.CallStackDepth));
                    // If an exception occured, rethrow it unless this
                    // callstack frame was the first
                    if (parameter.CallStackDepth != 0) throw;
                    // If this frame was the first in callstack, restart the
                    // thread but this time without throwing an exception (for
                    // demonstrate such a restart character like your Proxies do)
                    BuildUpCallStack(new ThreadStartParameter {
                        Id = parameter.Id,
                        CallStackDepth = 0,
                        ThrowException = false
                    });
                }
                return;
            }
            DoSomething(parameter);
        }
        static void DoSomething(object data) {
            ThreadStartParameter parameter = (ThreadStartParameter)data;
            for (int counter = 0; counter < 7; counter++) {
                if (counter == 3 && parameter.ThrowException)
                    throw new MyException();
                Log(parameter.Id);
                Thread.Sleep(100);
            }
        }
        static void Log(object message) {
            Console.WriteLine(
                "    {0:HH:mm:ss.ffff} [{1}] {2}",
                DateTime.Now,
                Thread.CurrentThread.Name,
                message.ToString());
        }
    }
