    private void button1_Click(object sender, EventArgs e)
    {
        string orange = "orange";
        stringp[] lines = richTextBox1.Lines;
        foreach(string line in lines)
        {
        int a = line.IndexOf(orange);
        if(a >0)
        {
          var b = line.ElementAt(a);
 
          textBox1.Text = b.ToString();
        }
    }
