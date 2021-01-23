    public interface IPseudoImmutable
    {
        bool IsFrozen { get; }
        bool Freeze();
    }
