    try {
        Cursor.Current = Cursors.WaitCursor;
        try {
            MyProcessingTask();
        }
        finally {
            Cursor.Current = Cursors.Default;
        }
    }
    catch (Exception ex) {
        MessageBox.Show(ex.ToString());
    }
