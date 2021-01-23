      namespace ConsoleApplication2
        {
            using System;
            using System.Collections.Generic;
        
            public class Program
            {
                private static readonly int[] OrderNumbers = new int[5];
        
                public static void Main(string[] args)
                {
                    for (var i = 0; i < OrderNumbers.Length; i++)
                    {
                        OrderNumbers[i] = InputOrderNumber();
                    }
                }
        
                private static int InputOrderNumber()
                {
                    Console.Write("Enter order number: ");
                    var orderNumber = Convert.ToInt32(Console.ReadLine());
                    if (((IList<int>)OrderNumbers).Contains(orderNumber))
                    {
                        Console.WriteLine("Order number {0} is a duplicate.", orderNumber);
                        return InputOrderNumber();
                    }
        
                    return orderNumber;
                }
            }
        }
