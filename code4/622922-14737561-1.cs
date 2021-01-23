    SizeF stringSize = new SizeF();
    private void groupBox1_Paint(object sender, PaintEventArgs e)
    {
        string measureString = "this is your text";
        Font stringFont = new Font("Arial", 17);
        // Measure string.
        stringSize = e.Graphics.MeasureString(measureString, stringFont);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        groupBox1.Text = "this is your text";
        groupBox1.Width = (int)stringSize.Width;
    }
 
