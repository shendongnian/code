    using System;
    using System.Collections.Generic;
    public class Main1{
    public Main1()
        {
             FibonacciRecursiveList = new List<int>();
             GetFibonacci(5,20);
        }
     private List<int> FibonacciRecursiveList;
     private void GetFibonacci(int StartNUmber, int LastNumber)
        {
            if (StartNUmber < LastNumber)
            {
                if (FibonacciRecursiveList.Count == 0 || FibonacciRecursiveList.Count == 1)
                {
                    FibonacciRecursiveList.Add(StartNUmber);
                }
                else
                {
                    int value = FibonacciRecursiveList[FibonacciRecursiveList.Count - 1] + FibonacciRecursiveList
    
    [FibonacciRecursiveList.Count - 2];
                    FibonacciRecursiveList.Add(value);
                }
                StartNUmber++;
                GetFibonacci(StartNUmber, LastNumber);
            }
            else
            {
               return;
            }
        }
    
     public static void Main(string[] args) {
         
         Main1 main = new Main1();
         foreach(int a in main.FibonacciRecursiveList){
             Console.WriteLine(a);
         }
     }
    }
