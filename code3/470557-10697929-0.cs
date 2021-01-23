    using System;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
    
            try
            {
                var files = from file in Directory.EnumerateFiles(@"c:\something",
                                "*.gz", SearchOption.AllDirectories)
                            select new
                            {
                                File = file,
                            };
    
                foreach (var f in files)
                {
                    Process.Start("c:\winrar.exe", f.File);
                }
    			Console.WriteLine("{0} files found and extracted!", 
    				files.Count().ToString());
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }
    }
