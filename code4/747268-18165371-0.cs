    var result = JsonConvert.DeserializeObject<Response>(data);  
---  
    public class SightingType
    {
        public string BrandId { get; set; }
        public List<string> DestinationUserIds { get; set; }
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEnabled { get; set; }
        public string Name { get; set; }
    }
    public class Response
    {
        public object Message { get; set; }
        public int Status { get; set; }
        public int CurrentVersionNumber { get; set; }
        public List<SightingType> SightingTypes { get; set; }
    }
