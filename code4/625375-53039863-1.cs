               int[] arr = {-10, -3, -3, -6};
               int h = int.MinValue, m = int.MinValue;
    
                        foreach (var t in arr)
                        {
                            if (t == h || t == m)
                                continue;
                            if (t > h)
                            {                            
                                m = h;
                                h = t;
                            }
                            else if(t > m )
                            {                            
                                m = t;
                            }
                            
                        }
    
                Console.WriteLine("High: {0} 2nd High: {1}", h, m);
                       //or,
                m = arr.OrderByDescending(i => i).Distinct().Skip(1).First();
    
                Console.WriteLine("High: {0} 2nd High: {1}", h, m);
