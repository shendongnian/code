    protected void AddMoreSkills_Click(object sender, EventArgs e)
    {
        Table tblmain = new Table();
        tblmain.ID = "tblmain";
        tblmain.Width = Unit.Percentage(100);
        tblmain.Attributes.CssStyle.Add("margin-top", "5px");
        tblmain.Attributes.CssStyle.Add("margin-bottom", "5px");
    
        TableCell tblTCell;
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        
        tblRow = new TableRow();
        tblCell = new TableCell();
        Label lblTown = new Label();
        lblTown.ID = "lblSkill";
        lblTown.Text = "Skill";
        tblCell.Controls.Add(lblTown);
        tblRow.Cells.Add(tblCell);
    
        TextBox txtSkill = new TextBox();
        txtSkill.ID = "txtSkill";
        tblTCell = new TableCell();
        tblTCell.Controls.Add(txtSkill);
        tblRow.Cells.Add(tblTCell);
        tblmain.Rows.Add(tblRow);
    
        form1.Controls.Add(tblmain);
    }
