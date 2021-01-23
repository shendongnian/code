    protected void btnItem_Click(object sender, CommandEventArgs e)
    {
        var control = (Control)sender;
        var container = control.NamingContainer;
        var textBox = container.FindControl("tbItem") as TextBox;
        if (textBox != null)
        {
            var lineID = e.CommandArgument;
            var text = textBox.Text;
        }
    }
