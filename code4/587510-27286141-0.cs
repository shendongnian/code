    class Program
        {
            static void Main(string[] args)
            {
                int[] arr = new int[100000000];
    
                Random randNum = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = randNum.Next(-100000000, 100000000);
                }
                Stopwatch stopwatch1 = new Stopwatch();
                Stopwatch stopwatch2 = new Stopwatch();
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch1.Start();
    
                var max = GetMaxFullIterate(arr);
    
                Debug.WriteLine( stopwatch1.Elapsed.ToString());
             
    
                stopwatch2.Start();
                var max2 = GetMaxPartialIterate(arr);
              
                Debug.WriteLine( stopwatch2.Elapsed.ToString());
    
                stopwatch3.Start();
                var max3 = arr.Max();
                Debug.WriteLine(stopwatch3.Elapsed.ToString());
    
            }
    
    
    
     private static int GetMaxPartialIterate(int[] arr)
            {
                var max = arr[0];
                var idx = 0;
                for (int i = arr.Length / 2; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
    
                    if (arr[idx] > max)
                    {
                        max = arr[idx];
                    }
                    idx++;
                }
                return max;
            }
    
    
            private static int GetMaxFullIterate(int[] arr)
            {
                var max = arr[0];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
                return max;
            }
