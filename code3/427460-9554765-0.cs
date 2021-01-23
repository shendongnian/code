    public class SomethingWithADictionary {
        private Dictionary<string, Instance> Instances { get; set; } 
        [System.Runtime.CompilerServices.IndexerNameAttribute("Instances")]
        public  Instance this [String skillId]{
          // Add getters and setters to manipulate Instances dictionary 
        }
    }
