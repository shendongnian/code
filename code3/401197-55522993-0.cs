    public interface IFoo 
    {
        [JsonIgnore]
        string SecretProperty  { get; set; }
        string Include { get; set; }
	}
    public class Foo : IFoo 
    {
        public string SecretProperty  { get; set; }
        public string Include { get; set; }
    }
