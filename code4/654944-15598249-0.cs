    static void Main(string[] args)
            {
    
                Thread worker = new Thread(DoBackgroundWork);
            }
    
            public static void DoBackgroundWork()
            {
    
    
                while (true)
                {
                    //Sleep 10 seconds
                    Thread.Sleep(10000);
    
                    //Do some work and than post to the control using Invoke()
    
                }
    
            }
