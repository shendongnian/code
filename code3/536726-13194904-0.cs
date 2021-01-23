    using System;
    using System.Collections.Generic;
 
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {  Test(0);
             Test(1);
             Test(16);
             Test(250);
          }
 
          private static void Test(int failsPerSet)
          {  Dictionary<int, bool> items = new Dictionary<int,bool>();
 
             for(int i =  0; i < 10000; i++)
                if(i >= failsPerSet)
                   items[i] = true;
 
             if(failsPerSet == 0)
                RawLookup(items, failsPerSet);
 
             GuardedLookup(items, failsPerSet);
 
             CaughtLookup(items, failsPerSet);
 
          }
 
          private static void RawLookup
          (  Dictionary<int, bool> items
          ,  int             failsPerSet
          ){ int                   found = 0;
             DateTime              start ;
 
             Console.Write("Raw     (");
             Console.Write(failsPerSet);
             Console.Write("): ");
 
             start = DateTime.Now;
             for(int i = 0; i < 50000000; i++)
             {  int pick = i % 10000;
                if(items[pick])
                   found++;
             }
 
             Console.WriteLine(DateTime.Now - start);
          }
 
          private static void GuardedLookup
          (  Dictionary<int, bool> items
          ,  int             failsPerSet
          ){ int                   found = 0;
             DateTime              start ;
 
             Console.Write("Guarded (");
             Console.Write(failsPerSet);
             Console.Write("): ");
 
             start = DateTime.Now;
             for(int i = 0; i < 50000000; i++)
             {  int pick = i % 10000;
                if(items.ContainsKey(pick))
                   if(items[pick])
                      found++;
             }
 
             Console.WriteLine(DateTime.Now - start);
          }
 
          private static void CaughtLookup
          (  Dictionary<int, bool> items
          ,  int             failsPerSet
          ){ int                   found = 0;
             DateTime              start ;
 
             Console.Write("Caught  (");
             Console.Write(failsPerSet);
             Console.Write("): ");
 
             start = DateTime.Now;
             for(int i = 0; i < 50000000; i++)
             {  int pick = i % 10000;
                try
                {  if(items[pick])
                      found++;
                }
                catch
                {  
                }
             }
 
             Console.WriteLine(DateTime.Now - start);
          }
 
       }
    }
