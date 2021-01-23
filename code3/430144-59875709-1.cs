        var serviceCollection = new ServiceCollection();
        var baseUri = new Uri("http://www.test.com");
        serviceCollection.AddSingleton(typeof(ISerializationAdapter), typeof(NewtonsoftSerializationAdapter));
        serviceCollection.AddSingleton(typeof(ILogger), typeof(ConsoleLogger));
        serviceCollection.AddSingleton(typeof(IClient), typeof(Client));
        serviceCollection.AddDependencyInjectionMapping();
        serviceCollection.AddTransient<TestHandler>();
        //Make sure the HttpClient is named the same as the Rest Client
        serviceCollection.AddSingleton<IClient>(x => new Client(name: clientName, httpClientFactory: x.GetRequiredService<IHttpClientFactory>()));
        serviceCollection.AddHttpClient(clientName, (c) => { c.BaseAddress = baseUri; })
            .AddHttpMessageHandler<TestHandler>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var client = serviceProvider.GetService<IClient>();
        await client.GetAsync<object>();
