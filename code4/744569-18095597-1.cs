    Config config = new Config();
    for(int i = 0; i < 50; i++)
    {
         config.GetType().GetProperty(i).SetValue(config, port.ReadLine());
    }
