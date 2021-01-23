    [TestInitialize]
    public void SetThrowUnobservedTaskExceptions()
    {
        Type taskExceptionHolder = typeof(Task).Assembly
            .GetType("System.Threading.Tasks.TaskExceptionHolder", false);
        if (taskExceptionHolder != null)
        {
            var field = taskExceptionHolder.GetField("s_failFastOnUnobservedException",
                BindingFlags.Static | BindingFlags.NonPublic);
            field.SetValue(null, true);
        }
    }
