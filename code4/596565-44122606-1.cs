        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
        using System.IO;
        using System.Linq;
        using System.Web;
        /// <summary>
        /// Summary description for RScriptRunner
        /// </summary>
        public class RScriptRunner
        {
            public RScriptRunner()
            {
                //
                // TODO: Add constructor logic here
                //
            }
            // Runs an R script from a file using Rscript.exe.
            /// 
            /// Example: 
            ///
            ///   RScriptRunner.RunFromCmd(curDirectory +         @"\ImageClustering.r", "rscript.exe", curDirectory.Replace('\\','/'));
            ///   
            /// Getting args passed from C# using R:
            ///
            ///   args = commandArgs(trailingOnly = TRUE)
            ///   print(args[1]);
            ///  
            ///   
            /// rCodeFilePath          - File where your R code is located.
            /// rScriptExecutablePath  - Usually only requires "rscript.exe"
            /// args                   - Multiple R args can be seperated by spaces.
            /// Returns                - a string with the R responses.
            public static string RunFromCmd(string rCodeFilePath, string         rScriptExecutablePath, string args)
            {
                string file = rCodeFilePath;
                string result = string.Empty;
                try
                {
                    var info = new ProcessStartInfo();
                    info.FileName = rScriptExecutablePath;
                    info.WorkingDirectory =         Path.GetDirectoryName(rScriptExecutablePath);
                    info.Arguments = rCodeFilePath + " " + args;
                    info.RedirectStandardInput = false;
                    info.RedirectStandardOutput = true;
                    info.UseShellExecute = false;
                    info.CreateNoWindow = true;
                    using (var proc = new Process())
                    {
                        proc.StartInfo = info;
                        proc.Start();
                        result = proc.StandardOutput.ReadToEnd();
               
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("R Script failed: " + result, ex);
                }
            }
        }
