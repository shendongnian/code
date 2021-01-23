        public class Test : IDisposable
        {
            public void Dispose()
            {
                // release other necessary ressources if needed
                Console.WriteLine("Disposed");
            }
        }
 
        {
            using (IDisposable disposable = new Test())
            {
                
            }
        }
