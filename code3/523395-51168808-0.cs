    // This is used for set the transaction timeout to 40 minutes.
    Type oSystemType = typeof(global::System.Transactions.TransactionManager);
    System.Reflection.FieldInfo oCachedMaxTimeout = 
                        oSystemType.GetField("_cachedMaxTimeout", 
                        System.Reflection.BindingFlags.NonPublic | 
                        System.Reflection.BindingFlags.Static);
    System.Reflection.FieldInfo oMaximumTimeout = 
                        oSystemType.GetField("_maximumTimeout", 
                        System.Reflection.BindingFlags.NonPublic | 
                        System.Reflection.BindingFlags.Static);
    oCachedMaxTimeout.SetValue(null, true);
    oMaximumTimeout.SetValue(null, TimeSpan.FromSeconds(2400));
