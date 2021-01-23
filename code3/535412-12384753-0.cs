     //add using System.Diagnostics;
    
     public static void Main()
        {
            int runs = 900000;
            HObject hob1;
            HObject hob2;
            HObject hob3;
            HObject hob4;
            HObject hob5;
            HObject hob6;
    
            Stopwatch t1 = new Stopwatch();
         
            t1.Start();
    
            for ( int i = 0; i < runs; i++ )
            {
                doItMethod(out hob1, out hob2, out hob3, out hob4, out hob5, out hob6);
            }
    
            t1.Stop();
    
    
            Stopwatch t2 = new Stopwatch();
            t2.Start();
    
            for ( int i = 0; i < runs; i++ )
            {
                HOperatorSet.GenEmptyObj(out hob1);
                HOperatorSet.GenEmptyObj(out hob2);
                HOperatorSet.GenEmptyObj(out hob3);
                HOperatorSet.GenEmptyObj(out hob4);
                HOperatorSet.GenEmptyObj(out hob5);
                HOperatorSet.GenEmptyObj(out hob6);
    
                hob1.Dispose();
                hob2.Dispose();
                hob3.Dispose();
                hob4.Dispose();
                hob5.Dispose();
                hob6.Dispose();
            }
            t2.Stop();
    
           
    
            Console.WriteLine("Zeitspanne Methodenaufruf : " + t1.ElapsedMilliseconds);
            Console.WriteLine("Zeitspanne direkter Aufruf: " + t2.ElapsedMilliseconds);
    
            Console.ReadKey();
        }
