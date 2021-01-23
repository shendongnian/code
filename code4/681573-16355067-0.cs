    protected void TextBox1_TextChanged (object sender, EventArgs e)
    {
        Label1.Text = "";
        try
        {
          int colWidth = Int16.Parse(Server.HtmlEncode(TextBox1.Text));
          if (colWidth > 0)
          {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
              GridView1.Columns[i].ItemStyle.Width = colWidth;
            }
          }
        }
        catch
        {
          Label1.Text = "An error occurred."
        }
    }
