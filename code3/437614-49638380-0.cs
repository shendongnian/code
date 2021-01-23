    In Dot Net Core, follow the instructions at https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl
    
    ***In your startup.cs add the following,***
    
    // Requires using Microsoft.AspNetCore.Mvc;
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add(new RequireHttpsAttribute());
        });`enter code here`
    
    ***To redirect Http to Https, add the following in the startup.cs***
    
    // Requires using Microsoft.AspNetCore.Rewrite;
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
    
        var options = new RewriteOptions()
           .AddRedirectToHttps();
    
        app.UseRewriter(options);
