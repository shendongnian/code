    public class CellRef : IEquatable<CellRef>
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        // some more code...
    }
    public class CellRange : IEquatable<CellRange>
    {
        public CellRef Start { get; private set; }
        public CellRef Stop { get; private set; }
        // some more code...
    }
