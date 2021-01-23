    // on the class level
    private bool isClosed = false;
           
    void OnCellMouseClick(object sender, DataGridViewCellMouseEventArgs e) 
    {    
       if (e.ColumnIndex == 2 && (ktlg == null || this.isClosed))     
       { 
            this.Cursor = Cursors.WaitCursor
            if (ktlg == null)
            {
               ktlg = new FormKatalog();
               ktlg.FormClosed += (s, e) => this.isClosed = true;
            }
            this.isClosed = false;
            ktlg.Show();         
            this.Cursor = Cursors.Default; 
       }
    }
