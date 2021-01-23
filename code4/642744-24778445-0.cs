    private bool Validation()
            { 
             foreach ( RadioButton rbtn in filetypepnl.Controls)
             {
             if(rbtn.Checked)
             {
                 return true;
             }
             }
             return false;
            }
        
