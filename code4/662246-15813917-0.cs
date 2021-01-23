    public bool HasNoStatements(Delegate del)
    {
        // Null arg-checking omitted.
        const byte nop = 0;
        var ilArray = del.Method.GetMethodBody().GetILAsByteArray();
        return ilArray.Take(ilArray.Length - 1).All(b => b == nop);
    }
