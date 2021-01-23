    static class Program
    {
        static Random r = new Random();
        static int Window = 50; //(small to facilitate visual functional test). eventually could be 100 1000, but not more than 5000.
        const int FullDataSize =1000;
        static double[] InputArr = new double[FullDataSize]; //array prefilled with the random input data.
        //====================== Caching algo variables
        static double Low = 0;
        static int LowLocation = 0;
        static int CurrentLocation = 0;
        static double[] Result1 = new double[FullDataSize]; //contains the caching mimimum result
        static int i1; //incrementor, just to store the result back to the array. In real life, the result is not even stored back to array.
        //====================== Ascending Minima algo variables
        static double[] Result2 = new double[FullDataSize]; //contains ascending miminum result.
        static double[] RollWinArray = new double[Window]; //array for the caching algo
        static Deque<MinimaValue> RollWinDeque = new Deque<MinimaValue>(); //Niro.Deque nuget.
        static int i2; //used by the struct of the Deque (not just for result storage)
        
        //====================================== my initialy proposed caching algo
        static void CalcCachingMin(double currentNum)
        {
            RollWinArray[CurrentLocation] = currentNum;
            if (currentNum <= Low)
            {
                LowLocation = CurrentLocation;
                Low = currentNum;
            }
            else if (CurrentLocation == LowLocation)
                ReFindHighest();
            CurrentLocation++;
            if (CurrentLocation == Window) CurrentLocation = 0; //this is faster
            //CurrentLocation = CurrentLocation % Window; //this is slower, still over 10 fold faster than ascending minima
            Result1[i1++] = Low;
        }
        //full iteration run each time lowest is overwritten.
        static void ReFindHighest()
        {
            Low = RollWinArray[0];
            LowLocation = 0; //bug fix. missing from initial version.
            for (int i = 1; i < Window; i++)
                if (RollWinArray[i] < Low)
                {
                    Low = RollWinArray[i];
                    LowLocation = i;
                }
        }
        //======================================= Ascending Minima algo based on http://stackoverflow.com/a/14823809/2381899 
        private struct MinimaValue
        {
            public int RemoveIndex { get; set; }
            public double Value { get; set; }
        }
        public static void CalcAscendingMinima (double newNum)
        { //same algo as the extension method below, but used on external arrays, and fed with 1 data point at a time like in the projected real time app.
                while (RollWinDeque.Count > 0 && i2 >= RollWinDeque[0].RemoveIndex)
                    RollWinDeque.RemoveFromFront();
                while (RollWinDeque.Count > 0 && RollWinDeque[RollWinDeque.Count - 1].Value >= newNum)
                    RollWinDeque.RemoveFromBack();
                RollWinDeque.AddToBack(new MinimaValue { RemoveIndex = i2 + Window, Value = newNum });
                Result2[i2++] = RollWinDeque[0].Value;
        }
        public static double[] GetMin(this double[] input, int window)
        {   //this is the initial method extesion for ascending mimima 
            //taken from http://stackoverflow.com/a/14823809/2381899
            var queue = new Deque<MinimaValue>();
            var result = new double[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var val = input[i];
                // Note: in Nito.Deque, queue[0] is the front
                while (queue.Count > 0 && i >= queue[0].RemoveIndex)
                    queue.RemoveFromFront();
                while (queue.Count > 0 && queue[queue.Count - 1].Value >= val)
                    queue.RemoveFromBack();
                queue.AddToBack(new MinimaValue { RemoveIndex = i + window, Value = val });
                result[i] = queue[0].Value;
            }
            return result;
        }
        //============================================ Test program.
        static void Main(string[] args)
        { //this it the test program. 
            //it runs several attempts of both algos on the same data.
            for (int j = 0; j < 10; j++)
            {
                Low = 12000;
                for (int i = 0; i < Window; i++)
                    RollWinArray[i] = 10000000;
                //Fill the data + functional test - generate 100 numbers and check them in as you go:
                InputArr[0] = 12000;
                for (int i = 1; i < FullDataSize; i++) //fill the Input array with random data.
                    //InputArr[i] = r.Next(100) + 11000;//simple data.
                    InputArr[i] = InputArr[i - 1] + r.NextDouble() - 0.5; //brownian motion data.
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < FullDataSize; i++) //run the Caching algo.
                    CalcCachingMin(InputArr[i]);
                stopwatch.Stop();
                Console.WriteLine("Caching  : " + stopwatch.ElapsedTicks + " mS: " + stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < FullDataSize; i++) //run the Ascending Minima algo
                    CalcAscendingMinima(InputArr[i]);
                stopwatch.Stop();
                Console.WriteLine("AscMimima: " + stopwatch.ElapsedTicks + " mS: " + stopwatch.ElapsedMilliseconds);
                stopwatch.Reset();
                i1 = 0; i2 = 0; RollWinDeque.Clear();
            }
            for (int i = 0; i < FullDataSize; i++) //test the results.
                if (Result2[i] != Result1[i]) //this is a test that algos are valid. Errors (mismatches) are printed.
                    Console.WriteLine("Current:" + InputArr[i].ToString("#.00") + "\tLowest of " + Window + "last is " + Result1[i].ToString("#.00") + " " + Result2[i].ToString("#.00") + "\t" + (Result1[i] == Result2[i])); //for validation purposes only.
            Console.ReadLine();
        }
    }
 
