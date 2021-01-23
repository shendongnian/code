         /// <summary>
         /// Calculate the optimal bins for the given data
         /// </summary>
         /// <param name="x">The data you have</param>
         /// <param name="xMin">The minimum element</param>
         /// <param name="optimalBinWidth">The width between each bin</param>
         /// <returns>The bins</returns>
         public static int[] CalculateOptimalBinWidth(List<double> x, out double xMin, out double optimalBinWidth)
         {
            var xMax = x.Max();
            xMin = x.Min();
            optimalBinWidth = 0;
            const int MIN_BINS = 1;
            const int MAX_BINS = 20;
            int[] minKi = null;
            var minOffset = double.MaxValue;
            foreach (var n in Enumerable.Range(MIN_BINS, MAX_BINS - MIN_BINS).Select(v => v*5))
            {
               var d = (xMax - xMin)/n;
               var ki = Histogram(x, n, xMin, d);
               var ki2 = ki.Skip(1).Take(ki.Length - 2).ToArray();
               var mean = ki2.Average();
               var variance = ki2.Select(v => Math.Pow(v - mean, 2)).Sum()/n;
               var offset = (2*mean - variance)/Math.Pow(d, 2);
               if (offset < minOffset)
               {
                  minKi = ki;
                  minOffset = offset;
                  optimalBinWidth = d;
               }
            }
            return minKi;
         }
         private static int[] Histogram(List<double> data, int count, double xMin, double d)
         {
            var histogram = new int[count];
            foreach (var t in data)
            {
               var bucket = (int) Math.Truncate((t - xMin)/d);
               if (count == bucket) //fix xMax
                  bucket --;
               histogram[bucket]++;
            }
            return histogram;
         }
