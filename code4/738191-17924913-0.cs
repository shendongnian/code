    class DoubleBufferedTreeView : TreeView {
        public MyTreeView() {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
