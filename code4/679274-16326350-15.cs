    namespace COMTest
    {
        class Program
        {
            private static MyAppDotNetWrapper app;
            static void Main( string[] args )
            {
                //create a new instance of the wrapper
                app = new MyAppDotNetWrapper();
                //Add the onclose event handler
                app.WBBondPointCloseEvent += OnAppClose;
    
                //call my com interface method
                Console.WriteLine("Val = " + app.GetVal().ToString());
                Console.WriteLine("Val = " + app.GetVal().ToString());
                string s = Console.ReadLine();
            }
            static voic OnClose(string s)
            {
                Console.WriteLine("Com Application Closed.");
            }
        }
    }
