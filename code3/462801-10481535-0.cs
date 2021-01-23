    void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e) {
        GridViewRow row = ((Control) sender).NamingContainer as GridViewRow;
        PopulateClients(txtName1, txtLName1, txtAddr1, txtPhone1, row);
    
        //If I hit another select button then this will load the sencond set of txtboxes
        PopulateClients(txtName2, txtLName2, txtAddr2, txtPhone2, row);
        //The thrid time will load the third button and so on until I fill each txtbox if I choose.
    }
    private void PopulateClients(TextBox t1, TextBox t2, TextBox t3, TextBox t4, GridViewRow r) {
        if (string.IsNullOrEmpty(t1.Text) && string.IsNullOrEmpty(t2.Text) && string.IsNullOrEmpty(t3.Text) && string.IsNullOrEmpty(t4.Text)) {
            t1.Text = Server.HtmlDecode(r.Cells[1].Text);
            t2.Text = Server.HtmlDecode(r.Cells[2].Text);
            t3.Text = Server.HtmlDecode(r.Cells[3].Text);
            t4.Text = Server.HtmlDecode(r.Cells[4].Text);    
        }
    }​
