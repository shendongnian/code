    for (int x = 0; x < dt.Rows.Count; x++)
    {
        TextBox txt = new TextBox();
        txt.TextChanged += new EventHandler(txt_TextChanged);
        txt.Name = dt.Rows[x]["field_name"].ToString();
        txt.Text = txt.Name;
        txt.Width = 200;
        var margintx = txt.Margin;
        margintx.Bottom = 5;
        txt.Margin = margintx;
        flowLayoutPanelText.Controls.Add(txt);
    }
    void txt_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        if (tb.Name == "Mag Data")
        {
            //Do Stuff Here
        }
    }
