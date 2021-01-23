    protected void Session_Start(object sender, EventArgs e)
    {
        Session["Stuff"] = LoadMyDataAsync();
    }
    static async Task<int> LoadMyDataAsync()
    {
        await Task.Delay(1000);
        return 13;
    }
