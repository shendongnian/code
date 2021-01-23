    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace FourCC
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fourCC = "YUY2";
                char[] values = fourCC.ToCharArray();
                string hexString = "";
                foreach (char letter in values.Reverse())
                { 
                    int value = Convert.ToInt32(letter);
     
                    string hexOutput = String.Format("{0:X}", value);
    
                    hexString += hexOutput;
    
                    Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
                }
                Console.WriteLine("Reversed (little-endian) hex value of {0} is {1}", fourCC, hexString);
                Console.ReadKey();
    
            }
        }
