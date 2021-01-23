    static public bool ContainsType(this Array array, Type type)
    {
        int len = array.Length; // Note that putting this in the loop is slightly slower
                                // because the compiler can't assume that a property value
                                // remains constant.
        for (int i = 0; i < len; i++)
        {
            if (array.GetValue(i).GetType() == type) return true;
        }
        return false;
    }
