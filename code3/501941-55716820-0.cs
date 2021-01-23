    services.AddMvc().AddJsonOptions(o =>
    {
        o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
        // ^^ IMPORTANT PART ^^
    }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
