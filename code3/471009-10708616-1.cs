    public enum ParameterEnum 
    {
        Alpha = 1,
        Bravo = 2
    }
    
    public ParameterContainer
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public ParameterEnum Parameter {get;set;}
    }
    
    public class ResponseElement
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public ParameterContainer[] Parameters { get; set; }
    }
