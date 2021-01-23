    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    
    namespace SelfNgenPoC
    {
        class Program
        {
            static void Main(string[] args)
            {
                /*
                 * Check whether the app has been NGen'd with code adapted from
                 * http://stackoverflow.com/a/20593260/1810429, which also outlines
                 * an alternative approach - by running...
                 *     ngen.exe display <assemblyPath>
                 * ...and checking the result - 0 if the app is already NGen'd and
                 * -1 if it is not.
                 */
    
                Process process = Process.GetCurrentProcess();
    
                ProcessModule[] modules = new ProcessModule[process.Modules.Count];
                process.Modules.CopyTo(modules, 0);
    
                var niQuery =
                    from m in modules
                    where m.FileName.Contains(@"\" + process.ProcessName + ".ni")
                    select m.FileName;
                bool ni = niQuery.Count() > 0 ? true : false;
    
                // FORNOW: for PoC debugging and sanity checking
                if (ni)
                    Console.WriteLine("Native Image: " + niQuery.ElementAt(0));
                else
                    Console.WriteLine("IL Image: " + process.MainModule.FileName);
    
                /*
                 * NGen the app if not.
                 */
    
                if (!ni)
                {
                    // FORNOW: for PoC debugging and sanity checking
                    Console.WriteLine("The app is not NGen'd.");
                    Console.WriteLine("NGen'ing the app...");
    
                    var assemblyPath = process.MainModule.FileName;
    
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    // TODO: Determine the path to (the appropriate version of)
                    // ngen.exe.
                    // FORNOW: Just use a hardcoded path to ngen.exe for PoC.
                    startInfo.FileName =
                        @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\ngen.exe";
                    startInfo.Arguments = "install \"" + assemblyPath + "\"";
                    // TBD: process options that you think make sense
                    startInfo.CreateNoWindow = false;
                    startInfo.UseShellExecute = false;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
    
                    try
                    {
                        using (Process exeProcess = Process.Start(startInfo))
                        {
                            exeProcess.WaitForExit();
                        }
                    }
                    catch
                    {
                        // TBD: error handling that you think makes sense - e.g.
                        // logging or displaying the error, moving on regardless
                        // etcetera.
                    }
                }
                else
                {
                    // FORNOW: for PoC debugging and sanity checking
                    Console.WriteLine("The app is already NGen'd.");
                }
    
                /*
                 * Carry on with whatever your app does.
                 */
            }
        }
    }
