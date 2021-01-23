    private void trackBar_Scroll(object sender, System.EventArgs e)
    {
        // TextBox also dynamic? One way is using ControlCollection.Find
        textBox1 = this.Controls.Find("textBox1", true).FirstOrDefault() as TextBox;
        if(textBox1 != null)
            textBox1.Text = trackBar1.Value.ToString();
    }
