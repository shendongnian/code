    for (int i = 0; i < objectArray.Length; ++i)
    {
        ComputeStringFunctionViaFunc(objectArray[i].ToStringHelper);
    }
    static class Extensions
    {
        public static string ToStringHelper(this object obj)
        {
            return obj.ToString();
        }
    }
