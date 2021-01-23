    using System;
    using Microsoft.Office.Interop.Outlook;
    class Program
    {
        static void Main(string[] args)
        {
            var oApp = new Application();
            var oNS = oApp.GetNamespace("MAPI");
            Stores stores = oNS.Stores;
            foreach (Store store in stores)
            {
                Console.WriteLine("Name: {0} \n Path: {1} \n Type: {2} \n IsDataFileStore: {3}", 
                                    store.DisplayName, store.FilePath, store.ExchangeStoreType, store.IsDataFileStore);
                
                Console.WriteLine(Environment.NewLine);
            }
           
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
