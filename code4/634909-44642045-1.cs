    services.AddMvc(opts =>
    {
        var jsonFormatter = (JsonOutputFormatter) opts.OutputFormatters
            .First(formatter => formatter is JsonOutputFormatter);
        jsonFormatter.PublicSerializerSettings.Converters.Add(new StringEnumConverter());
    });
