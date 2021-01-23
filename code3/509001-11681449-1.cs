    var s = @"{ ""A"": { ""B"": 1, ""Test"": ""123"", ""C"": { ""Test"": [ ""1"", ""2"", ""3"" ] } } }";
    var json = JObject.Parse(s);
    
    var renamed = Rename(json, name => name == "Test" ? "TestRenamed" : name);
    renamed.ToString().Dump();  // LINQPad output
    
    var dict = new Dictionary<string, string> { { "Test", "TestRenamed"} };
    var renamedDict = Rename(json, dict);
    renamedDict.ToString().Dump();  // LINQPad output
