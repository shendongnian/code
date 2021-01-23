     class Program
        {
            static void Main(string[] args)
            {
                RunWithTimeout((token) =>
                                   {
                                       Thread.Sleep(2000);
                                       if (token.Cancel)
                                       {
                                           Console.WriteLine("Canceled");
                                       }
                                   }, 1000);
    
                Console.ReadLine();
            }
    
            private class Token
            {
                public bool Cancel { get; set; }
            }
    
            static void RunWithTimeout(Action<Token> entryPoint, int timeout)
            {
    
                Token token = new Token();
    
                var thread = new Thread(() => entryPoint(token)) { IsBackground = true };
    
                thread.Start();
    
                if (!thread.Join(timeout))
                    token.Cancel = true;
            }
        }
