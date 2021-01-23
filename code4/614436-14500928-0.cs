    abstract class MemoryCardSize
    {
        public int MegaBytes { get; protected set; }
    }
    class TwoGB : MemoryCardSize { public TwoGB() { MegaBytes = 2024; } }
    class FourGB : MemoryCardSize { public FourGB() { MegaBytes = 4048; } }
    class EightGB : MemoryCardSize { public EightGB() { MegaBytes = 8096; } }
