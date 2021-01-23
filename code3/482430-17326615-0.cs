    Dim task = New Threading.Tasks.Task(Of dllClass)(Function()
                                                         Return New dllClass()
                                                     End Function)
    task.Start()
    task.Wait()
    public static dllClass dllClassInstance = task.Result;
    void worker1_DoWork(object sender, DoWorkEventArgs e)
    {
        dllClassInstance.TimeConsumingMethod();
    }
