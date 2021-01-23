    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            List<double> listOfFactors = new List<double>();
            public void FindFactors()
            {
                double num = 600851475143 / 2;
                for (int i = 1; i <= (num/2); i++)
                {
                    if (600851475143 % i == 0)
                    {
                        listOfFactors.Add(i);
                    }
                }
            }
            static void Main(string[] args)
            {
                Program cl = new Program();
                cl.FindFactors();
            }
        }
    }
   
   
