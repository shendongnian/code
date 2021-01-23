    void Page_Load (object sender, EventArgs e)
    {
        foreach (Control c in picktexts.Controls)
        {
            ((TextBox)c).TextChanged += new EventHandler(MyTextBox_TextChanged);
        }
    }
