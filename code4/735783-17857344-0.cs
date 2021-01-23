    public class Model
    {
        public string FishSpecies { get; set; }
        public int Length { get; set; }
        public static IEnumerable<Model> Load() { ... }
    }
