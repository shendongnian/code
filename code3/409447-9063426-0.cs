    public void UseLambda<T> (IEnumerable<T> source , Func<IEnumerable, IEnumerable> lambda)
    {
        var items= lambda(source);
        
        foreach(var item in items)
           Console.Writeline(item.ToString());
        }
    }
