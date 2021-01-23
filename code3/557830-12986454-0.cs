    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (DropDownList1.SelectedIndex == 0)
         {
             entryForm.Visible = true;
             viewForm.Visible = false;
         }
         else if (DropDownList1.SelectedIndex == 1)
         {
             entryForm.Visible = false;
             viewForm.Visible = true;
    
    }
