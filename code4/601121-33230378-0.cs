    protected async void Page_Load(object sender, EventArgs e)
    {
       var tasks = websites.Select(GenerateSomeContent);
       await Task.WhenAll(tasks);
    }
