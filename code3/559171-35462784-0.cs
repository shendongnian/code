                List<int> result = new List<int>();
                if (number == 0)
                {
                    result.Add(0);
                    return result;
                }
                else if (number == 1)
                {
                    result.Add(1);
                    return result;
                }
                else
                {
                    //if we got thus far,we should have f1,f2 and f3 as fibonacci numbers
                    int f1 = 0,
                        f2 = 1,
                        f3 = 1;
                    result.AddRange(new List<int>() { f1, f2, f3 });
                    for (int i = 3; i <= number; i++)
                    {
                        result.Add(result[i - 1] + result[i - 2]);
                    }
                }
                return result;
                 
            }
