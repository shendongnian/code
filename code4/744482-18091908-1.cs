                StackTrace st = new StackTrace();
                StackTrace st1 = new StackTrace(new StackFrame(true));
                Console.WriteLine(" Stack trace for Main: {0}",
                   st1.ToString());
                Console.WriteLine(st.ToString());
