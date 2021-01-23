    var settings = new JsonSerializerSettings();
    settings.Error += (o, args) => {
    	if(args.ErrorContext.Error.InnerException is NotImplementedException)
    		args.ErrorContext.Handled = true;
    };
    
    var s = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, settings);
