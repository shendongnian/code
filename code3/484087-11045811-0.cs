public class Output
{
   [JsonProperty(PropertyName="LGA11aAust.DistanceToBorder")]
   public decimal DistanceToBorder {get; set;}
   //All the other properties
   
}
//Usage
var deserializedObjects = JsonConvert.DeserializeObject<List<Output>>(someJsonResult)
