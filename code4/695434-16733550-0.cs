    private static string[] GetCode()
    {
      return new string[]
            {
              @"using System;
                using System.Collections;
                namespace test
                {
                    public class DummyHelloWorldHandler 
                    {
                        protected internal Queue _queue;  
                        public void Received(string message) 
                        {
                            lock (_queue) 
                            { 
                                _queue.Enqueue(message); 
                            }
                            Console.WriteLine(""Enqueued"");
                        } 
                        public DummyHelloWorldHandler() 
                        {
                            _queue = new Queue(); 
                        } 
                    }
                }"
            };
    }
