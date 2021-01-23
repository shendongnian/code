    using System;
    
    namespace ScrapCSConsole
    {
       class ScrapCSConsole
       {
          public static void Main()
          {
             Console.WriteLine("Create StaticDemo A");
             StaticDemo a = new StaticDemo();
             Console.WriteLine("Create StaticDemo B");
             StaticDemo b = new StaticDemo();
             Console.WriteLine("Done");
          }
       }
    
       class StaticDemo
       {
          private static int staticDemo1;
          private static int staticDemo2 = 0;
          private static int staticDemo3 = default(int);
          private static int staticDemo4;
          private static int classNumber;
    
          /// <summary>
          /// Static Constructor
          /// </summary>
          static StaticDemo()
          {
             Console.WriteLine("Static Constructor");
             Console.WriteLine("staticDemo1 {0}", staticDemo1);
             staticDemo4 = (new DateTime(1999, 12, 31)).DayOfYear;
          }
          /// <summary>
          /// Instance Constructor
          /// </summary>    
          public StaticDemo()
          {
             classNumber++;
             Console.WriteLine("classNumber {0}", classNumber);
             Console.WriteLine("staticDemo2 {0}", staticDemo2);
             Console.WriteLine("staticDemo3 {0}", staticDemo3);
             Console.WriteLine("staticDemo4 {0}", staticDemo4);                  
          }      
       }
    }
