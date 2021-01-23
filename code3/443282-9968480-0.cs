    private void Form_Load(object sender, System.EventArgs e)
    {
        foreach (var btn in this.Controls.OfType<Button>())
        {
            btn.Click += AllButtonClick;
        }
    }
    private void AllButtonClick(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        String buttonText = btn.Text;
    }
