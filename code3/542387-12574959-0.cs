    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.IO.StreamReader myFileStream;
                string strFileLine;
                String[] arrAddressString;
        
                myFileStream = new System.IO.StreamReader("c:\\myTextFile.txt");
                // where "c:\\myTextFile.txt" is the file path and file name.
                while ((strFileLine = myFileStream.ReadLine()) != null)
                {
                    arrAddressString = strFileLine.Split('.');
        
                /*
                   Now we have a 0-based string arracy
                   p.q.r.s: such that arrAddressString[0] = p, arrAddressString[1] = q,
                   arrAddressString[2] = r, arrAddressString[3] = s
                */
                /* here you do whatever you want with the values in the array. */
                    // Here, i'm just outputting the elements...
                    for (int i = 0; i < arrAddressString.Length; i++)
                    {
                        System.Console.WriteLine(arrAddressString[i]);
                    }
                    System.Console.ReadKey();
                 }
            }
        }
    }
   
