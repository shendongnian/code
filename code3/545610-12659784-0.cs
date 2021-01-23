    static void ProcessWithWaitCursor(this Action task)
    {
        try {
            Cursor.Current = Cursors.WaitCursor;
            task();
        }
        catch (Exception ex) {
            Cursor.Current = Cursors.Default;
            MessageBox.Show(ex.ToString());
        }
        finally { Cursor.Current = Cursors.Default; }
