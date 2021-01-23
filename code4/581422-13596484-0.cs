    void Form1_Click(object sender, EventArgs e)
    {
        if (sender is Panel)
        {
            Panel panel = sender as Panel;
             
            if (panel.Name.equals("Panel1"))
            {
                 .. ...
            }
        }
    }
