    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                //test();
                testMax();
                Console.ReadLine();
            }
    
            static void testMax()
            {
                List<int> CheckPrimes = Enumerable.Range(2, 1000000).ToList();
                PrimeChecker pc = new PrimeChecker(1000000);
                foreach (int i in CheckPrimes)
                {
                    if (pc.isPrime(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    
        public class PrimeChecker{
            public List<int> KnownRootPrimesList;
            public int HighestKnownPrime = 3;
            
            public PrimeChecker(int Max=1000000){
                KnownRootPrimesList = new List<int>();
                KnownRootPrimesList.Add(2);
                KnownRootPrimesList.Add(3);
                isPrime(Max);
            }
    
            public bool isPrime(int value)
            {
                int srt = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Convert.ToDouble(value))));
                if(srt > HighestKnownPrime)
                {
                    for(int i = HighestKnownPrime + 1; i <= srt; i++)
                    {
                        if (i > HighestKnownPrime)
                        {
                            if(isPrimeCalculation(i))
                            {
                                    KnownRootPrimesList.Add(i);
                                    HighestKnownPrime = i;
                            }
                        }
                    }
                }
                bool isValuePrime = isPrimeCalculation(value);
                return(isValuePrime);
            }
    
            private bool isPrimeCalculation(int value)
            {
                if (value < HighestKnownPrime)
                {
                    if (KnownRootPrimesList.BinarySearch(value) > -1)
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                }
                int srt = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Convert.ToDouble(value))));
                bool isPrime = true;
                List<int> CheckList = KnownRootPrimesList.ToList();
                if (HighestKnownPrime + 1 < srt)
                {
                    CheckList.AddRange(Enumerable.Range(HighestKnownPrime + 1, srt));
                }
                foreach(int i in CheckList)
                {
                    isPrime = ((value % i) != 0);
                    if(!isPrime)
                    {
                        break;
                    }
                }
                return (isPrime);
            }
    
            public bool isPrimeStandard(int value)
            {
                int srt = Convert.ToInt32(Math.Ceiling(Math.Sqrt(Convert.ToDouble(value))));
                bool isPrime = true;
                List<int> CheckList = Enumerable.Range(2, srt).ToList();
                foreach (int i in CheckList)
                {
                    isPrime = ((value % i) != 0);
                    if (!isPrime)
                    {
                        break;
                    }
                }
                return (isPrime);
            }
        }
    }
