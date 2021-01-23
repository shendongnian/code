    public class Tricorn
    {
       public string RocketFuel { get; set; }
    
       public bool ShouldSerializeRocketFuel()
       {
          return !string.IsNullOrEmpty(this.RocketFuel.Length);
       }
    }
