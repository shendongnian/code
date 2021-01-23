    protected void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
             GridViewRow row = (GridViewRow)(((CheckBox)sender).NamingContainer);
             HiddenField hdnCheck=(HiddenField)row.Cells[4].FindControl("hiddenField1");
             if (Convert.ToString(hdnCheck.Value != "")
               {
                   Response.Write("true");
               }
               else
               {
                   Response.Write("fasle");
               }
           Edit:-//You can easily get Checkbox which has been cheked,and do your logic
             CheckBox chkSelect=(CheckBox)sender;
             if (chkSelect.Checked)
               {
                   Response.Write("true");
               }
               else
               {
                   Response.Write("fasle");
               }    
        }
