    [DebuggerDisplay("{ToDebugString()}")]
    public class SomeClass
    {
        public override String ToString()
        {
            return "Normal ToString()";
        }
        public String ToDebugString()
        {
            return "ToDebugString()";
        }
     }
