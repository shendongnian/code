    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                int i = 0; //initialize integer i=0
                int sum = 0; // initialize integer sum = 0;
                int[] arr = new int[]{1, 2, 3, 4}; // array containing 4 integers elements
                do
                {
                   
                    {
                        sum+=arr[i];    //sum each integer in array and store it in var sum
                       
                        i++;        //increment i for each element of array
                        Console.WriteLine(sum); //output the var sum conatining values after each increment
                    }
    
                }
                while(i<=3); //check condition for number of elements in array
             
            }
        }
    }
