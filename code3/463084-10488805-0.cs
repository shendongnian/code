    public static void RunInLoop<T>(IEnumerable<T> someCollection, 
                                     Func<T, bool> action)
    {           
            foreach (var item in someCollection)
            {
                    if(action(item))
                         break;
            }
    }
