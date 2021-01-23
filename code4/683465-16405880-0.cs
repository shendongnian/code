    public class ChannelSettings {
      Dictionary<string, double> _values = new Dictionary<string, double>();
       public double slider20Hz {
         get {
           double v;
           if (_values.TryGetValue("slider20Hz", out v)) {
             return v;
           }
           return 0.0; // Default value
         }
         set {
           _values["slider20Hz"] = value;
         }
       }
    
       . . . 
       public void SetByName(string name, double value) {
         _values[name] = value;
       }
    }
