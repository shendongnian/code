    namespace ParallelProgramming.Playground
    {
        public class SomeClass
        {
            public Task Foo()
            {
                return Bar();
            }
    
            private static Task Bar()
            {
                return Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("I fired off. Thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(5000);
                        return true; //or whatever else you want.
                    });
            }
        }
    
        [TestClass]
        public class StackOverflow
        {
            [TestMethod]
            public void TestFoo()
            {
                // Arrange
                var obj = new SomeClass();
    
                var results = new ConcurrentBag<Task>(); 
                var waitForMe = Task.Factory.StartNew(() =>
                    {
                        // Act
                        results.Add(obj.Foo());
                        results.Add(obj.Foo());
                        results.Add(obj.Foo());
    
                        return true;
                    });
    
    
                Task.WaitAll(waitForMe);
    
                // Assert
                /* I need something to wait on all tasks to finish */
                Assert.IsTrue(waitForMe.Result);
                Assert.AreEqual(3, results.Count);
            }
        }
    }
