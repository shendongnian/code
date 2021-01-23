    public static void RefreshDatabaseCache(
        string connectionString)
    {
        // The type of the ADODB connection. Used for dynamically creating.
        var adodbType = Type.GetTypeFromProgID(@"ADODB.Connection");
        // The main ADODB connection object.
        var adodbInstance = Activator.CreateInstance(adodbType);
        // --
        // Open the connection.
        adodbType.InvokeMember(
            @"Open",
            BindingFlags.InvokeMethod,
            null,
            adodbInstance,
            new object[]
            {
                connectionString,
                string.Empty,
                string.Empty,
                0
            });
        try
        {
            // The type of the JET engine. Used for dynamically creating.
            var jroType = Type.GetTypeFromProgID(@"JRO.JetEngine");
            // The main JET engine object.
            var jroInstance = Activator.CreateInstance(jroType);
            // Refresh the cache.
            jroType.InvokeMember(
                @"RefreshCache",
                BindingFlags.InvokeMethod,
                null,
                jroInstance,
                new[]
                {
                    adodbInstance
                });
        }
        finally
        {
            // Close the connection.
            adodbType.InvokeMember(
                @"Close",
                BindingFlags.InvokeMethod,
                null,
                adodbInstance,
                new object[]
                {
                });
        }
    }
