    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace stdio
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.SetOut(System.IO.TextWriter.Null);
                Console.WriteLine("This will go to > null");
                WriteOutput("This is written to standard output");
                Console.WriteLine("This will also go to > null");
                Console.ReadKey();
            }
            static void WriteOutput(String someString)
            {
                Console.SetOut(Console.Out);
                Stream output = Console.OpenStandardOutput();
                StreamWriter sw = new StreamWriter(output);
                sw.Write(someString);
                sw.Flush();
                sw.Close();
                output.Close();
                Console.SetOut(System.IO.TextWriter.Null);
            }
        }
    }
