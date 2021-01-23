    public class BufferedListView : ListView
    {
        public BufferedListView() : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
