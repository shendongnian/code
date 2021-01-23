       class Program
        {
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);           
                
        
            }
        
            static void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
                Console.WriteLine("exit");
            }
        }
