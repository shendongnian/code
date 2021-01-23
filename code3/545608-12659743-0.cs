            Exception exception = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MyProcessingTask();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Cursor.Current = Cursors.Default;
            if (exception!= null)
                MessageBox.Show(exception.ToString());
