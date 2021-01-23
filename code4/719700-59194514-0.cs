    public class KeyValue
    {
        public string errorCode
        {
            get; set;
        }
    
        public string errorMessage
        {
            get; set;
        }
    }
    string json = @"[{""errorCode"":""code1"",""errorMessage"":""value1""}, {""errorCode"":""code2"",""errorMessage"":""value2""}, {""errorCode"":""code3"",""errorMessage"":""value3""}] ";
    JavaScriptSerializer deserializer = new JavaScriptSerializer();
    List<KeyValue> items = deserializer.Deserialize<List<KeyValue>>(json);
     
    foreach(var item in items)
    {
        Console.WriteLine(item.errorCode + ":" + item.errorMessage);
    }
   
