    // we need to add the async keyword to the method signature
    public async void TheEnclosingMethod()
    {
        tbkLabel.Text = "two mins delay";
    
        await Task.Delay(2000);
        var page = new Page2();
        page.Show();
    }
