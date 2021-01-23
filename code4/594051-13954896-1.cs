    // set up unity container, register all types
    UnityContainer container = new UnityContainer();
    container.RegisterType<IApiRegistrationRequest, ApiRegistrationRequest>();
    // save existing formatters and remove them from the config
    List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>(GlobalConfiguration.Configuration.Formatters);
    GlobalConfiguration.Configuration.Formatters.Clear();
    // create an instance of our custom formatter for each existing formatter
    foreach (MediaTypeFormatter formatter in formatters)
    {
        GlobalConfiguration.Configuration.Formatters.Add(new UnityFormatter(formatter, container));
    }
