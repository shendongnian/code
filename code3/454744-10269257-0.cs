    private void Charmove_Load(object sender, EventArgs e)
    {
        ...
        timer1.Stop();
        Messagebox.Show("You've won the stage. Well done!");
        this.Close();
        g.Show();
    }
