    public interface IPseudoRandomFunction : IDisposable
    {
        int HashSize { get; }
        byte[] Transform(byte[] input);
    }
