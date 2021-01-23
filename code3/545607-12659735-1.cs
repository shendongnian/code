    try {
        try {
            Cursor.Current = Cursors.WaitCursor;
            MyProcessingTask();
        }
        finally { Cursor.Current = Cursors.Default; }
    }
    catch (Exception ex) {
        MessageBox.Show(ex.ToString());
    }
