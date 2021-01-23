    public class ChannelSettings {
      Dictionary<string, double> _values = new Dictionary<string, double>();
       public double slider20Hz {
         get {
           return GetByName("slider20Hz");
         }
         set {
           _values["slider20Hz"] = value;
         }
       }
    
       . . . 
       public void SetByName(string name, double value) {
         _values[name] = value;
       }
       public double GetByName(string name) {
         double v;
         if (_values.TryGetValue("slider20Hz", out v)) {
           return v;
         }
         return 0.0; // Default value
       }
    }
