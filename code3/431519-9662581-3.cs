    string check = ExecuteWithIdentity(identity, "Foo", 10, SomeComplexAction);
    ...
    private static string SomeComplexAction(IAzApplication3 application,
                                            IAzClientContext3 context)
    {
        // Do complex checks here, returning whether the user is allowed to
        // perform the operation
    }
