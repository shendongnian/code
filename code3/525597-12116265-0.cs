    /// <summary>
    /// Defines an interface to calculate relevant 
    /// to the input complexity of a string
    /// </summary>
    public interface IStringComplexity
    {
        double GetCompressionRatio(string input);
        double GetRelevantComplexity(double min, double max, double current);
    }
