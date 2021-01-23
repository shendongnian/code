    using Microsoft.Web.Administration;
    
    //..
    
    var serverManager = new ServerManager();
    foreach (var site in serverManager.Sites)
    {
        Console.WriteLine("Site: {0}", site.Name);
        foreach (var app in site.Applications)
        {
            Console.WriteLine(app.Path);
        }
    }
