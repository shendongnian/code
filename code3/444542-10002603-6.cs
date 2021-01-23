    class Tester
    {
        int simS;
        Queue<double> simarrivals;
        double[] simarrivalsArray;
        int head = 0;
        double leadtime = 5.0;
        internal Tester()
        {
            this.simS = 300;
            simarrivalsArray = new double[simS];
            simarrivals = new Queue<double>(simS + 1);
            for (int i = 0; i < simS; i++)
            {
                simarrivals.Enqueue(0.0);
            }            
        }
        internal void TestQueues()
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            double withdrawals = 5.0E+8;
            for (double d = 0.0; d < withdrawals; d += 1.0)
            {
                simWithdrawalFast(d);
            }
            Console.WriteLine("Own implementation:  "+ sw.ElapsedMilliseconds);
            System.Diagnostics.Stopwatch sw2 = System.Diagnostics.Stopwatch.StartNew();
            for (double d = 0.0; d < withdrawals; d += 1.0)
            {
                simWithdrawalFast2(d);
            }
            Console.WriteLine("Queue:  "+sw2.ElapsedMilliseconds);
        }
        double simWithdrawalFast(double time)
        {
            double returnValue = simarrivalsArray[head]; //Withdrawal 
            simarrivalsArray[head++] = time + leadtime; //Enqueue 
            if (head == simS)//simS is length of array/queue, which stays constant; 
            {
                head = 0;
            }
            return returnValue;
        }
        double simWithdrawalFast2(double t)
        {
            simarrivals.Enqueue(t + leadtime);
            return simarrivals.Dequeue();
        }
    }
