     protected void buttonSubmit_Click(object sender, EventArgs e)
     {
         if(string.IsNullOrEmpty(textName.Text))
         {
             panelError.Visible = true;
         }
         else
         {
             // Save to Database, whatever
         }
     }
