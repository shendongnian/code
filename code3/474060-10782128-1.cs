    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication61
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] files = new[] { "Audio Files", "Text Files", "Video Files", "Other Files", "Application Files" };
                Array.Sort(files, new FileComparer());
                Console.Read();
            }
        }
    
        class FileComparer : IComparer<string>
        {
            static List<string> OrderedFiles = new List<string> { "Text Files", "Image Files", "Audio Files", "Video Files", "Application Files", "Other Files" };
    
            public int Compare(string x, string y)
            {
                int xi = OrderedFiles.IndexOf(x);
                int yi = OrderedFiles.IndexOf(y);
    
                if (xi > yi)
                    return 1;
    
                if (xi < yi)
                    return -1;
    
                return 0;
            }
        }
    }
