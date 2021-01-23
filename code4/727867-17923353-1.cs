    public void DoSomething()
    {
        var classC = new ClassB().DoSomethingElse();
        //SAVE CLASS c to database
        var serializeTask = classC.GetSerializedDataTable();
        // will obtain result if available, will block current thread and wait for serialized data if task still running.
        var serializedData = serializeTask.Result; 
    }
