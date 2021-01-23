    public static IEnumerable<double> GetMaxElements(this IEnumerable<double> source)
        {
            var usedIndices = new HashSet<int>();
            int count = source.Count();
            while (usedIndices.Count < count)
            {
                var enumerator = source.GetEnumerator();
                int index = 0;
                int maxIndex = 0;
                double maxValue = Double.NegativeInfinity;
                while(enumerator.MoveNext())
                {
                    if(enumerator.Current>maxValue&&!usedIndices.Contains(index))
                    {
                        maxValue = enumerator.Current;
                        maxIndex = index;
                    }
                    index++;
                }
                usedIndices.Add(maxIndex);
                yield return maxValue;
            }
        }
