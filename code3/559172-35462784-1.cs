     public static List<int> PrintFibonacci(int number)
            {
                List<int> result = new List<int>();
                if (number == 0)
                {
                    result.Add(0);
                    return result;
                }
                else if (number == 1)
                {
                    result.Add(0);
                    return result;
                }
                else if (number == 2)
                {
                    result.AddRange(new List<int>() { 0, 1 });
                    return result;
                }
                else
                {
                    //if we got thus far,we should have f1,f2 and f3 as fibonacci numbers
                    int f1 = 0,
                        f2 = 1;
    
                    result.AddRange(new List<int>() { f1, f2 });
                    for (int i = 2; i < number; i++)
                    {
                        result.Add(result[i - 1] + result[i - 2]);
                    }
                }
                return result;
    
            }
