    public static Func<A, double> ThrowIfNegative<A, double>(this Func<A, double> f)
    {
        return a=>
        { 
          double r = f(a);  
          // if r is NaN then this will throw.
          if ( !(r >= 0.0) )
            throw new Exception(); 
          return r;
        };
    }
    public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
    {
        var d = new Dictionary<A, R>();
        return a=>
        {
            R r;
            if (!d.TryGetValue(a, out r))
            {
              r = f(a);
              d.Add(a, r);
            }
            return r;
        };
    }
