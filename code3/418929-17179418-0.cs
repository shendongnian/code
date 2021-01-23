    protected void dvEvent_DataBound(object sender, EventArgs e)
    {
        
        int commandRowIndex = dvEvent.Rows.Count - 1;
        if (commandRowIndex > 0)
        {
            DetailsViewRow commandRow = dvEvent.Rows[commandRowIndex];
            DataControlFieldCell cell = (DataControlFieldCell)commandRow.Controls[0];
            
            foreach (Control ctrl in cell.Controls)
            {
                if (ctrl is ImageButton)
                {
                    ImageButton ibt = (ImageButton)ctrl;
                    if (ibt.CommandName == "Delete")
                    {
                        ibt.ToolTip = "Click here to Delete";
                        ibt.CommandName = "Delete";
                        ibt.Attributes["onClick"] = "if (!confirm('Are you sure " +
                                    "you want to delete this record?')) return;";
                    }
                }
            }
        }
    }
