    public static void CheckAndThrowArgNullEx(params object[] argsAndNames)
    {
        for (int i = 0; i < argsAndNames.Length; i += 2)
        {
            if (argsAndNames[i] == null)
            {
                string argName = (string)argsAndNames[i + 1];
                throw new ArgumentNullException(argName);
            }
        }
    }
