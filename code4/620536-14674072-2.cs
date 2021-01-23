    public class Wrapper
    {
         dynamic version_info { get; set; }
         dynamic SKU_info { get; set; }
         Device device { get; set; }
    }
    
    Wrapper root = JsonConvert.DeserializeObject<Wrapper>(feed);
