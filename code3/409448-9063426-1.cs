    public void UseLambda<T> (IEnumerable<T> source 
                              ,Func<IEnumerable<T>, IEnumerable<T>> lambda)
    {
        var items= lambda(source);
        
        foreach(var item in items)
           Console.Writeline(item.ToString());
        }
    }
