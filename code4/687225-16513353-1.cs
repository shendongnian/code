    var config = new DotlessConfiguration
    {
    	LogLevel = LogLevel.Error,
    	// Put your custom logger implementation here
    	Logger = typeof(LessCssLogger)
    };
    
    var lessEngine = new EngineFactory(config).GetEngine();
    var outputCss = lessEngine.TransformToCss(response.Content, null);
    Response.Content = outputCss;
