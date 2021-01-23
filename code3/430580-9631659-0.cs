    private void CallSP(string param0, string param2 = null)
    {
        ...
        object value = ((object)param2) ?? DBNull.Value;
        // ^^^ use value in the parameter
        ...
    }
