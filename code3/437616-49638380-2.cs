    // Requires using Microsoft.AspNetCore.Rewrite;
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
    
        var options = new RewriteOptions()
           .AddRedirectToHttps();
    
        app.UseRewriter(options);
