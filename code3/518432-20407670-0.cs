    var result = obj.ToObject<MyClass>();
    public class MyClass 
    { 
        [JsonProperty("date_field")]
        public DateTime MyDate {get;set;}
    }
