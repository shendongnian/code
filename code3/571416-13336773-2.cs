     var linesPerProcessor = (int)(((lines.Count/4) / Environment.ProcessorCount)*4);
     Parallel.For(0,Environment.ProcessorCount -1
                ) =>
                    {
                       for (int i = (p * linesPerProcessor); i < (p+1)*linesPerProcessor; i+=4)
                       {
                              result.Add(string.Format ("{0},{1},{2},{3}", 
                                    lines[i], lines[i+1], lines[i+2], lines[i+3]));
                       }
                    }
                );
 
