    public interface IRandomNumberGenerator
    {
        Int32 NextInt();
    }
    public static class RandomNumberGeneratorExtensions
    {
        public static Double NextDouble(this IRandomNumberGenerator instance)
        {
            return (Double)Int32.MaxValue / (Double)instance.NextInt();
        }
    }
    // Now any class which implements IRandomNumberGenerator will get the NextDouble() method for free...
