    public class SomethingToDoWithCoconuts
    {
        [TextBlob(nameof(CoconutWaterBrandsBlobbed))]
        public List<string> CoconutWaterBrands { get; set; }
        public string CoconutWaterBrandsBlobbed { get; set; } // serialized CoconutWaterBrands
    }
