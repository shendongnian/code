    // this is in the DLL defining the interface
    public interface IXyz
    {
        int X { get; }
        int Y { get; }
        int Z { get; }
    }
    // this would be in the client DLL that you dynamically load in your code
    public class Xyz : IXyz
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
