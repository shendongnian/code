     protected void create_dynamic_text(object sender, EventArgs e)
    {
        int num = 5; // you can give the number here
        for (int i = 0; i < num;i++ )
        {
            TextBox tb = new TextBox();
            tb.ID = "txt_box_name" + i.ToString();
            tb.CssClass = "add classes if you need";
            tb.Width = 400; //Manage width and height 
            panel.Controls.Add(tb); //panel is my ASP.Panel object. Look above for the design code of ASP panel
        }
    }
