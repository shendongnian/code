    var json = "[{\"name\":\"joe\",\"message\":\"hello\",\"sent\":\"datetime\"},{\"name\":\"steve\",\"message\":\"bye\",\"sent\":\"datetime\"}]";
    var serializer = new JavaScriptSerializer();
    var result = serializer.Deserialize<object[]>(json);
    // now have an array of objects, each of which happens to be an IDictionary<string, object>
    foreach(IDictionary<string, object> map in result)
    {
        var messageValue = map["message"].ToString();
        Console.WriteLine("message = {0}", messageValue);
    }
    
