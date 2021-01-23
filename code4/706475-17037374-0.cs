    namespace _17036954
    {
        class Program
        {
            static void Main(string[] args)
            {
                AppDomain testApp = AppDomain.CreateDomain("testApp");
                try
                {
                    args = new string[] { };
                    string path = ConfigurationManager.AppSettings.Get("testApp");
    
                    //subscribe to ProcessExit before executing the assembly
                    testApp.ProcessExit += (sender, e) =>
                    {
                        //do nothing or do anything
                        Console.WriteLine("The appdomain ended");
                        Console.WriteLine("Press any key to end this program");
                        Console.ReadKey();
                    };
    
                    testApp.ExecuteAssembly(path);
                }
                catch (Exception ex)
                {
                    //Catch process here
                }
                finally
                {
                    AppDomain.Unload(testApp);
                }
            }
        }
    }
