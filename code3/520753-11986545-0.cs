    public class WaitCursor: IDisposable
    {
        private Cursor _previousCursor;
        public WaitCursor()
        {
           _previousCursor = Mouse.OverrideCursor;
           Mouse.OverrideCursor = Cursors.Wait;
        }
        pubic void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }
    }
