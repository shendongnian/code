    using System.Web.Script.Serialization;
    
    var jsonSerialization = new JavaScriptSerializer();
    var dictObj = jsonSerialization.Deserialize<Dictionary<string,dynamic>>(jsonText);
    Console.WriteLine(dictObj["some_number"]); //outputs 253.541
    Console.WriteLine(dictObj["more_data"]["field2"]); //outputs hello JSON Deserializer
