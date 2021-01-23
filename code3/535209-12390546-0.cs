    using System;
    using System.IO;
    using QuickFix;
    using QuickFix.DataDictionary;
    namespace TestQuickFix
    {
        class Program
        {
            private const int MAX_LINES = 10;
            static void Main(string[] args)
            {
                DataDictionary dd = new QuickFix.DataDictionary.DataDictionary("fix\\FIX50SP2.xml");   
                StreamReader file = new StreamReader(@"C:\secdef.dat");
                int count = 0; string line;
                while (((line = file.ReadLine()) != null && count++ < MAX_LINES))
                {
                    QuickFix.FIX50.SecurityDefinition secDef = new QuickFix.FIX50.SecurityDefinition();
                    secDef.FromString(line, false, dd, dd);
                    Console.WriteLine(secDef.SecurityDesc);
                }
                file.Close();
            }
        }
    }
