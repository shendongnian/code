    // Example query string from the question
    String test="Property1=A&Property2=B&Property3%5B0%5D%5BSubProperty1%5D=a&Property3%5B0%5D%5BSubProperty2%5D=b&Property3%5B1%5D%5BSubProperty1%5D=c&Property3%5B1%5D%5BSubProperty2%5D=d";
    // Convert the query string to a JSON-friendly dictionary
    var o=QueryStringHelper.QueryStringToDict(test);
    // Convert the dictionary to a JSON string using the JSON.NET
    // library <http://json.codeplex.com/>
    var json=JsonConvert.SerializeObject(o);
    // Output the JSON string to the console
    Console.WriteLine(json);
    
