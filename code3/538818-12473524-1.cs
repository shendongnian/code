    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
       {
         TextBox txt = new TextBox();
         txt.ID = "txt";
         control.Controls.Add(txt);
       }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       if (CheckBox1.Checked)
        {
           for (int ix = this.Controls.Count - 1; ix >= 0; ix--)
               if (this.Controls[ix] is TextBox) this.Controls[ix].Dispose();
           DropDownList ddl = new DropDownList();
           ddl.ID = "ddl";
          control.Controls.Add(ddl);
        }
        else
        {
          for (int ix = this.Controls.Count - 1; ix >= 0; ix--)
              if (this.Controls[ix] is DropDownList) this.Controls[ix].Dispose();
           TextBox txt = new TextBox();
           txt.ID = "txt";
           control.Controls.Add(txt);
        }
    }
