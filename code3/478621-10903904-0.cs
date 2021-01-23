    void DoWork(string parameter1, string parameter2, Action<string,string> customCode)
    {
        // ... Common code
        customCode(parameter1, parameter2);
        // ... Common code
        customCode(parameter1, parameter2);
        // ... Common code
    }
