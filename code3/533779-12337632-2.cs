    public interface IAlgorithmItem
    {
        SymmetricAlgorithm CreateAlgorithm();
        string DisplayName { get; }
    }
