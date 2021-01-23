    private static Teddy _getNext(string code, IEnumerable<Teddy> teddies)
    {
        return teddies.SkipWhile(i => !i.Code.Equals(code.ToUpper())).Skip(1).FirstOrDefault() 
           ?? teddies.First();
    }
    private static Teddy _getPrevious(string code, IEnumerable<Teddy> teddies)
    {
        return teddies.TakeWhile(i => !i.Code.Equals(code.ToUpper())).LastOrDefault() 
           ?? teddies.Last();
    }
