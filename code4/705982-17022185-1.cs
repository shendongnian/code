    while (rdr.Read())
    {
        DateTime temp = new DateTime();
        
        // This is the code that was added in.
        rid = new TableCell();
        rname = new TableCell();
        remail = new TableCell();
        rmobile = new TableCell();
        rdob = new TableCell();
        rstatus = new TableCell();
        rcheck = new TableCell();
        rview = new TableCell();
        redit = new TableCell();
        chk = new CheckBox();
        btnView = new Button();
        btnEdit = new Button();
        // Because I was creating new controls I also had to move my css classes to the loop as well
        rid.CssClass = "id";
        rname.CssClass = "name";
        remail.CssClass = "email";
        rmobile.CssClass = "mobile";
        rdob.CssClass = "dob";
        rstatus.CssClass = "status";
        rcheck.CssClass = "check";
        rview.CssClass = "button";
        redit.CssClass = "button";
        chk.Checked = false;
        btnView.Text = "View";
        btnEdit.Text = "Edit";
        rid.Text = rdr.GetValue(0).ToString();
        rname.Text = rdr.GetValue(1).ToString();
        remail.Text = rdr.GetValue(2).ToString();
        rmobile.Text = rdr.GetValue(3).ToString();
        DateTime.TryParse(rdr.GetValue(4).ToString(), out temp);
        rdob.Text = temp.ToString("dd/MM/yy");
        rstatus.Text = rdr.GetValue(5).ToString();
        chk.ID = rid.Text;
        btnView.PostBackUrl = string.Format("/VolunteerView.aspx?ID={0}", rid.Text);
        btnEdit.PostBackUrl = string.Format("/VolunteerEdit.aspx?ID={0}", rid.Text);
        rcheck.Controls.Add(chk);
        rview.Controls.Add(btnView);
        redit.Controls.Add(btnEdit);
        row = new TableRow();
        if (rowClass == "even")
            rowClass = "odd";
        else
            rowClass = "even";
        row.CssClass = rowClass;
        // Add cells to row
        row.Cells.Add(rid);
        row.Cells.Add(rname);
        row.Cells.Add(remail);
        row.Cells.Add(rmobile);
        row.Cells.Add(rdob);
        row.Cells.Add(rstatus);
        row.Cells.Add(rcheck);
        row.Cells.Add(rview);
        row.Cells.Add(redit);
                    
        // Add row to table
        result.Rows.Add(row);
    }
