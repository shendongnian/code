    // Requires using Microsoft.AspNetCore.Mvc;
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<MvcOptions>(options =>
        {
            options.Filters.Add(new RequireHttpsAttribute());
        });`enter code here`
    
