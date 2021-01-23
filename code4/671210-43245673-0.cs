    public void Main(string[] args)
    {
        var owinHost = new WebHostBuilder()
            .UseStartup<Startup>()
            .UseUrls("http://+:12345/")
            .Build();
 
        owinHost.Run();
    }
    
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseOwin(x => x.UseNancy());
        }
    }
