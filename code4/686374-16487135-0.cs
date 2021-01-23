    private static Teddy _getNext(string code, IEnumerable<Teddy> teddies)
    {
        return teddies.SkipWhile(i => !i.Code.Equals(code.ToUpper())).Skip(1).FirstOrDefault()
            ?? teddies.FirstOrDefault();
    }
