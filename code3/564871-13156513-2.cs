    private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
    { 
       if (!IsDataValid)
       {
           if(DialogResult.Yes == MessageBox.Show(Do you want to close this application?",
            "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
               this.Dispose(); //or Application.Exit();
           else
                e.Cancel = true;
       }
       else
           this.Dispose(); //or Application.Exit();
    }
