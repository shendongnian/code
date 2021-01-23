    public interface ISelected
    {
        // ISelected interface
    }
    // A TSelected implementation
    public class Implementation1: ISelected { }
    // Another
    public class Implementation2 : ISelected { }
    // our Rule
    private class Rule<TSource, TSelected> where TSource : class where TSelected ISelected
    {
    }
