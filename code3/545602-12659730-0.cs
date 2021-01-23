    class WaitingCursor : IDisposable
    {
        public WaitingCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
        }
        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
        }
    }
