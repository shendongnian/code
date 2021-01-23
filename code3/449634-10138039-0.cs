    public static void disableForm(this Form f)
        {
            foreach (Control c in f.Controls)
            {
                //f.Enabled = false;
                  c.Enabled = false;
             }
    
            f.Cursor = Cursors.WaitCursor;
        }
