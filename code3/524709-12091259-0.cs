    private void UpdateProgress(string step)
    {
        Messages.Clear(); // <- Why?
        Messages.Add(new Message(step));
        Thread.Sleep(1000);
    }
