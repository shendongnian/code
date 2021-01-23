    private void button1_Click(object sender, EventArgs e)
    {
        Visual_Options options = new Visual_Options();
        if ( options.ShowDialog() == DialogResult.OK)
            this.Size = options.getFormSize;  //This is a public property returning a size
    }
