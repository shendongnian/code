        #region WaitCursor
        public static IDisposable BeginWaitCursorBlock()
        {
            return ((!_waitCursorIsActive) ? (IDisposable)new waitCursor() : null);
        }
        private static bool _waitCursorIsActive;
        private class waitCursor : IDisposable
        {
            private Cursor oldCur;
            public waitCursor()
            {
                _waitCursorIsActive = true;
                oldCur = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            }
            public void Dispose()
            {
                Cursor.Current = oldCur;
                _waitCursorIsActive = false;
            }
        }
        #endregion
