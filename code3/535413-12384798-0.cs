    Method: 00:00:04.5573170
    Code: 00:00:04.5539918
 
    static void Main(string[] args)
        {
            int runs = 1000;
            HObject hob1;
            HObject hob2;
            HObject hob3;
            HObject hob4;
            HObject hob5;
            HObject hob6;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < runs; i++)
            {
                doItMethod(out hob1, out hob2, out hob3, out hob4, out hob5, out hob6);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw = Stopwatch.StartNew();
            for (int i = 0; i < runs; i++)
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
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }
