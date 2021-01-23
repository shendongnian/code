    using System;                                  //  ????????? DEBUG ?????????
    using sw = System.Diagnostics.Stopwatch;       //  static bool abc()    
    class Program                                  //  {   // a <= b <= c ?  
    {                                              //      int a=4,b=7,c=9;  
        static void Main()                         //      int i = 1;  
        {                                          //      if (a <= (a = b))  
            //abc();                               //      {  
            int i = 512;                           //          i++;  
            int[] a = new int[i--];                //          if (a <= (a = c))
            while (i > 0) a[i] = i--;              //          {    
            sw sw = sw.StartNew();                 //              i++;  
            for (i = 10000000; i > 0; i--)         //          }  
                isSorted(a);                       //      }  
            sw.Stop();                             //      return i > 2;  
            Console.Write(sw.ElapsedMilliseconds); //  }  
            Console.Read();                        //  static bool ABC();
        }                                          //  {
                                                   //      int[]a={4,7,9};    
        static bool isSorted(int[] a) // OP Cannon //      int i=1,j=2,ai=a[0]; 
        {                                          //  L0: if(i<=j)    
            for (int i = 1; i < a.Length; i++)     //        if(ai<=(ai=a[i]))  
                if (a[i - 1] > a[i]) return false; //          {i++;goto L0;}  
            return true;                           //      return i > j;  
        }                                          //  }  
    }
