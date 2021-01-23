    System.Windows.Forms.Button b = new System.Windows.Forms.Button();
    b.Click += new EventHandler(b_Click);
    //finally insert the button where it needs to be inserted.
    ...
    void b_Click(object sender, EventArgs e)
    {
        MessageBox.Show(((System.Windows.Forms.Button)sender).Name + " clicked");
    }
