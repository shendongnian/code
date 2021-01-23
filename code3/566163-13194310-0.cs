    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace ReadOnlyDirTest
    {
       class Program
       {
          [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
          extern static bool RemoveDirectory(string path);
    
          static String CreateTempDir()
          {
             String tempDir;
             do
             {
                tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
             } while (Directory.Exists(tempDir));
    
             Directory.CreateDirectory(tempDir);
             return tempDir;
          }
    
          static void Main(string[] args)
          {
             var tempDir = CreateTempDir();
             // Set readonly.
             new DirectoryInfo(tempDir).Attributes |= FileAttributes.ReadOnly;
    
             try
             {
                Directory.Delete(tempDir);
             }
             catch (Exception e)
             {
                Console.WriteLine("Directory.Delete: " + e.Message);
             }
    
             if (!Directory.Exists(tempDir))
                Console.WriteLine("Directory.Delete deleted directory");
    
             try
             {
                if (!RemoveDirectory(tempDir))
                   Console.WriteLine("RemoveDirectory Win32 error: " + Marshal.GetLastWin32Error().ToString());
             }
             catch (Exception e)
             {
                Console.WriteLine("RemoveDirectory: " + e.Message);
             }
    
             if (!Directory.Exists(tempDir))
                Console.WriteLine("RemoveDirectory deleted directory");
    
             // Try again without readonly, for both.
             tempDir = CreateTempDir();
             Directory.Delete(tempDir);
             Console.WriteLine("Directory.Delete: removed normal directory");
    
             tempDir = CreateTempDir();
             if (!RemoveDirectory(tempDir))
                Console.WriteLine("RemoveDirectory: could not remove directory, error is " + Marshal.GetLastWin32Error().ToString());
             else
                Console.WriteLine("RemoveDirectory: removed normal directory");
    
             Console.ReadLine();
          }
       }
    }
