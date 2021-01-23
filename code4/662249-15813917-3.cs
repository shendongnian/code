    public static bool IsEmpty(this Delegate del)
    {
        // Null arg-checking omitted.
        short nop = System.Reflection.Emit.OpCodes.Nop.Value;
        var ilArray = del.Method.GetMethodBody().GetILAsByteArray();
        return ilArray.Take(ilArray.Length - 1).All(b => b == nop);
    }
