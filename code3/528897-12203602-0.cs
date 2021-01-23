    public void ChangeButtonStyles(Control source)
    {
        foreach (Control con in source.Controls)
        {
            if (con is Button)
            {
                Button but = con as Button;
                but.FlatAppearance.BorderSize = 0;
                but.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                ChangeButtonStyles(con);
            }
        }
    }
