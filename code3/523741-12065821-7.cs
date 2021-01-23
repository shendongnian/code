    public void button4_Click(object sender, EventArgs e)
    {              
        Form2 f2 = new Form2(richTextBox1.Rtf);
        f2.ShowDialog();
        richTextBox1.Rtf= f2.richText;
     } 
