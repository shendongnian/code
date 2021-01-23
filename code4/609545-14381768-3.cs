    public WindowSettings OwningWindowSettings { get; set; }
    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
        if(OwningWindowSettings != null)
            OwningWindowSettings.Close();
    }
