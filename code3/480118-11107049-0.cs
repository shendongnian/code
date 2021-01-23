        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        using System.Diagnostics;
        using System.ComponentModel;
        namespace Stub
        {
          class Program
            {
              static void Main(string[] args)
                {
                // Declare variables and initialize
                string passWord = string.Empty;
                string processArgs = getArguments(args); //Call getArguments method
                Console.Write("Please enter the system password : ");
                passWord = readPassword(); //call readPassword method
           
                Process p = new Process();
                p.StartInfo.FileName = "myexe.exe";
                p.StartInfo.Arguments = processArgs;
                p.StartInfo.WorkingDirectory = "my_working_directory";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                StreamWriter sw = p.StandardInput;
                StreamReader sr = p.StandardOutput;
            
                writePassword(sr, sw, "password", passWord);
            
                sw.Close();
                sr.Close();
                p.WaitForExit();
                p.Close();
        }
        static string getArguments(string[] args)
        {
            StringBuilder procArgs = new StringBuilder();
            foreach (string arg in args)
            {
                procArgs.Append(arg);
                procArgs.Append(" ");
            }
            return procArgs.ToString();
        }
        
        static void writePassword(StreamReader sr, StreamWriter sw, string keyWord, string passWord)
        {
            string mystring;            
            do
            {
                mystring = sr.ReadLine();
            } while (!mystring.Contains(keyWord));
            if (mystring.Contains(keyWord))
                sw.WriteLine(passWord);
            else
                sw.WriteLine("\r\n");
        }
        static string readPassword()
        {
            string pass = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    pass +=key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return pass;
        }
    }
