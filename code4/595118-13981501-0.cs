     private void Looper()
            {
                int repeats = 100;
                float avg = 0;
    
                ArrayList times = new ArrayList();
    
                for (int i = 0; i < repeats; i++)
                    times.Add(Time()); 
    
                Console.WriteLine(GetAverage(times)); //44
    
                times.Clear();
    
                for (int i = 0; i < repeats; i++)            
                    times.Add(TimeUnrolled()); 
                
                Console.WriteLine(GetAverage(times)); //22
                
            }
    
     private float GetAverage(ArrayList times)
            {
                long total = 0;
                foreach (var item in times)
                {
                    total += (long)item;
                }
    
                return total / times.Count;
            }
    
            private long Time()
            {
                Stopwatch sw = new Stopwatch();
                int size = 20000000;
                int[] result = new int[size];
                sw.Start();
    
    
                for (int i = 0; i < size; i++)
                {
                    result[i] = 5;
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                return sw.ElapsedMilliseconds;
            }
    
            private long TimeUnrolled()
            {
                Stopwatch sw = new Stopwatch();
                int size = 20000000;
                int[] result = new int[size];
                sw.Start();
    
    
                for (int i = 0; i < size; i += 10)
                {
                    result[i] = 5;
                    result[i + 1] = 5;
                    result[i + 2] = 5;
                    result[i + 3] = 5;
                    result[i + 4] = 5;
                    result[i + 5] = 5;
                    result[i + 6] = 5;
                    result[i + 7] = 5;
                    result[i + 8] = 5;
                    result[i + 9] = 5;
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
                return sw.ElapsedMilliseconds;
            }
