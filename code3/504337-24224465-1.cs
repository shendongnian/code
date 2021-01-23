    string json = @"{ ""ObsoleteSetting"" : ""Gamma"" }";
    // deserialize
    Config config = JsonConvert.DeserializeObject<Config>(json);
    // migrate
    config.ReplacementSetting = 
        new Bang { Value = config.ObsoleteSetting.ToString() };
    // serialize
    json = JsonConvert.SerializeObject(config);
    Console.WriteLine(json);
