    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                File.Copy(@"C:\whatever\original.xlsx", @"C:\whatever\new.xlsx");
            }
        }
    }
