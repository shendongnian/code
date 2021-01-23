    private void Form1_Load(object sender, EventArgs e)
    {
        MyPanel p = new MyPanel();
        p.Size = new Size(500, 200); //give size
        this.Controls.Add(p); // add to form 
    }
