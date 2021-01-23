    void openNextForm()
    {
        Form f2 = new YourForm();    
        f2.owner=this;
        f2.FormClosing += new FormClosingEventHandler(f_FormClosing);
        f2.Show();
        this.Hide();
    }
    // When I close a child form by clicking cross or with ALT-F4
    void f_FormClosing(object sender, FormClosingEventArgs e)
    {
        Form f = sender as Form;
        f.Owner.Show();  // or simply ---- this.Show()
    }
