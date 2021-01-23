    // Somewhere in Main form - I'm imagining what you might be doing
    ...
    var menu = new MenuForm();
    menu.MainForm = this;       // insert this line
    menu.Show();
    // In menu form
    public STP2Main MainForm { get; set; }
    ...
    private void button1_Click(object sender, EventArgs e)
    {
        MainForm.set();
        this.Close();
    }
