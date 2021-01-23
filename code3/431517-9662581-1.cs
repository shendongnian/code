    bool check = CanPerform(identity, "Foo", 10, SomeComplexCheck);
    ...
    private static bool SomeComplexCheck(IAzApplication3 application,
                                         IAzClientContext3 context)
    {
        // Do complex checks here, returning whether the user is allowed to
        // perform the operation
    }
