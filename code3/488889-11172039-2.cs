    public class StockEventArgs : EventArgs
    {
        ...
        // Should restrict the setter as much as possible, here to the same assembly
        public int Index { get; internal set; }
    }
