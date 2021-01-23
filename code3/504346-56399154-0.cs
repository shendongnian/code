C#
[JsonProperty(NullValueHandling = NullValue.Ignore)]
public string MyProperty { get; set; }
If you are working on an ASP.NET Core web app, you can globally set this for all properties in all models by setting this in your Startup.cs file:
C#
public void ConfigureServices(IServiceCollection services) {
    // other configuration here
    services.AddMvc()
        .AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
}
