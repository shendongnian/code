    public async Task Foo()
    {
        await Task.Delay(2000);
        txtConsole.AppendText("Waiting...");
        DoStuff();
    }
