    class Sample : IEquatable<Sample>
    {
      private int _params;
      private Sample(int params) { _params = params; }
    
      private static HashSet<Sample> _samples = new HashSet<Sample>();
    
      public static GetSample(int params)
      {
        Sample s = new Sample(params);
        if (!_samples.ContainsKey(s))
          _samples.Add(s);
    
        return _samples[s];
      }
    }
