    public static IEnumerable<double> GetMaxElements(this IEnumerable<double> source)
        {
            var usedIndices = new HashSet<int>();
            while (true)
            {
                var enumerator = source.GetEnumerator();
                int index = 0;
                int maxIndex = 0;
                double? maxValue = null;
                while(enumerator.MoveNext())
                {
                    if((!maxValue.HasValue||enumerator.Current>maxValue)&&!usedIndices.Contains(index))
                    {
                        maxValue = enumerator.Current;
                        maxIndex = index;
                    }
                    index++;
                }
                usedIndices.Add(maxIndex);
                if (!maxValue.HasValue) break;
                yield return maxValue.Value;
            }
        }
