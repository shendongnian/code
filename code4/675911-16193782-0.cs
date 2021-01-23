    public void HandleClick(object sender, EventArgs e)
    {
        Console.WriteLine("Before");
        await Task.Delay(1000);
        Console.WriteLine("After");
    }
