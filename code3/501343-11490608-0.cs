    protected void isActive_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow gvrow = (GridViewRow)chkStatus.NamingContainer;
    
            //Get the ID which is the NetworkID of the employee
            string username = gvrow.Cells[2].Text;
            bool status = chkStatus.Checked;
    if(!status)//this is checkbox is unchecked then set backcolor to Gray
    {
    gvrow .BackColor = Color.Gray;
    }
    
    .......
