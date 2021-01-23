    // instead of Task, you could use void, but then you can't await its completion,
    // which could get handy later, depending on your use case
    public static async Task Execute(Func<YourClass, Task> externalStuff)
    {
        using (var obj = new YourClass()) // replace with your own initializer code
        {
            await externalStuff(obj);
        }
    }
