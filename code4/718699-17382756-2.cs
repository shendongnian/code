    string val = string.Empty;
     foreach (var ky in keys)
     {
                    
                    if (items.TryGetValue(ky, out val))
                    {
                        Console.WriteLine(val);
                    }
     
         }
