    private void btnSubmit_Click(object sender, EventArgs e)
    {
         if (AskToFillCommentIfNeeded()) {
             this.DialogResult = DialogResult.None; 
             return;
         }
    
         // ... save data and exit form ...
    }
