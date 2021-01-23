    private void button1_Click(object sender, EventArgs e)
    {
       // pictureBox1.Visible will be always set to true
       if (radioButton1.Checked)
       {
            pictureBox1.Load("10C.jpg");
       }
       else
       {
            pictureBox1.Load("placeholder.jpg");
       }
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.Visible = true;
        pictureBox1.Load("placeholder.jpg");
    }
