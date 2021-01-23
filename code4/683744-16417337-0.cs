    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            //replace with your strongly typed resource classes
            var rm1 = MyApplication.Properties.Resources.ResourceManager;
            var rm2 = MyApplication.Properties.Resources1.ResourceManager;
            var rs1 = rm1.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var rs2 = rm2.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            var result = from re1 in rs1.Cast<DictionaryEntry>()
                         join re2 in rs2.Cast<DictionaryEntry>()
                             on re1.Key equals re2.Key
                         select new { re1, re2 };
            foreach (var item in result)
            {
                Console.Write("Key with name \"{0}\" is present in ", 
                    item.re1.Key);
                Console.WriteLine("both files (\"{0}\" and \"{1}\")", 
                    item.re1.Value, item.re2.Value);
            }
        }
    }
