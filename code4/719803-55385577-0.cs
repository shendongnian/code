          BlockingCollection<int>[] sourceArrays = new BlockingCollection<int>[5];
      for(int i = 0; i < sourceArrays.Length; i++)
          sourceArrays[i] = new BlockingCollection<int>(500);
      Parallel.For(0, sourceArrays.Length * 500, (j) =>
                          {
                              int k = BlockingCollection<int>.TryAddToAny(sourceArrays, j);
                              if(k >=0)
                                  Console.WriteLine("added {0} to source data", j);
                          });
