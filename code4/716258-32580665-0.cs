    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().Configure<MvcOptions>(option => 
            {
                //Clear all existing output formatters
                option.OutputFormatters.Clear();
                var jsonOutputFormatter = new JsonOutputFormatter();
                //Set ReferenceLoopHandling
                jsonOutputFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //Insert above jsonOutputFormatter as the first formatter, you can insert other formatters.
                option.OutputFormatters.Insert(0, jsonOutputFormatter);
            });
        }
