    private void button1_Click(object sender, EventArgs e)
    {
         Derpy merp = new Derpy();
         merp.OnDerp += new EventHandler(herp);
            
    }
    void herp(object sender, EventArgs e)
    {
    }
