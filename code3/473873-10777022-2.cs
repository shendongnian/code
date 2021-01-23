    public static bool DoSomething(IBase item)
    {
        dynamic dynamicItem = item;
        // Dispatch dynamically based on execution-time type
        return DoSomethingSpecific(dynamicItem);
    }
    
