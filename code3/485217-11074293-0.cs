    public class MockContainer : IOpenFileDialog 
    {
        IOpenFileDialog FileDialog { get { return this; } }
    }
    public class RealContainer : IOpenFileDialog 
    {
        IOpenFileDialog FileDialog { get { return this; } }
    }
