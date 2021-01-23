    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace LineNumber
    {
        class Program
        {
            static System.IO.StreamReader sr;
            static int linenumber = 1;
            static string line;
            static void Main(string[] args)
            {
                try
               {
                    sr = new StreamReader("data.dat");
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (FindNumber(line) == true)
                        {
                            Console.WriteLine("Line Number : " + linenumber++);
                        }
                        else
                            linenumber++;
                    }
                    Console.WriteLine("End of File");
                    Console.ReadLine();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            static bool FindNumber(string line)
            {
                string[] linesplit;
                try
                {
                    if (line.Length == 0)
                        return false;
                    else
                    {
                        line = line.Replace("  "," ");
                   }
                    linesplit = line.Split(' ');
                    if(int.Parse(linesplit[9]) > 500)
                        return true;
                    else
                        return false;
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
