    [Serializable]
    public class EasyToSerialize
    {
        public string IAmNotTheProblem { get; set; }
      
        // other serializable properties
    }
    HardToSerialize x = ...;
    var foo2 = new EasyToSerialize {
        IAmNotTheProblem = x.IAmNotTheProblem
        // other properties here
    };
