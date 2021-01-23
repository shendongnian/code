    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Encrypt
    {
      class Program
      {
            static char[] alphabet = new char[52] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'z' };
        
           static void Main(string[] args)
           {
                string input = Console.ReadLine();
                string output = Decode(input);
                Console.WriteLine(output);
                Console.ReadLine();
           }
           static string Decode(string input)
           {
                string output = "";
                foreach (Char c in input)
                {
                   for (int i = 0; i < alphabet.GetLength(0); i++)
                   {
                      if (c == alphabet[i])
                      {
                         int intoutput = i + 1;
                         if (intoutput > 26)
                         {
                             intoutput = intoutput - 26;
                             output = output + "C" + intoutput + " ";
                         }
                         else
                         {
                             output = output + intoutput + " ";
                         }
                       }
                    }
                }
             return output;
           } 
         }
      }
