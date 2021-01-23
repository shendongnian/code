    using System;
    
    namespace LoopUntilSelectionTester
    {
        class Program
        {
            static void Main()
            {            
                string key;
                while((key = Console.ReadKey().KeyChar.ToString()) != "6")            
                {
                    int keyValue;                
                    int.TryParse(key, out keyValue);
    
                    ProcessInput(keyValue);
                }    
            }
    
            private static void ProcessInput(int keyValue)
            {
                switch (keyValue)
                {
                    case 1:
                        DoApps(reqObj);
                        break;
                    case 2:
                        DoDrivers(reqObj);
                        break;
                    case 3:
                        DoOS(reqObj);
                        break;
                    case 4:
                        DoPackages(reqObj);
                        break;
                    case 5:
                        DoAll(reqObj);
                        break;
                }
            }
        }
    }
