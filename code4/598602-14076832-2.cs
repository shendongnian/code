    private void button1_Click(object sender, EventArgs e)
    {
        using (StreamReader Reader = new StreamReader(@"C:\Original_Text_File.txt"))
        {
            var i = 0;
            while (!Reader.EndOfStream)
            {
                if (i % 12 == 11)
                {
                    //every 12 lines you read append new line instead of ,
                    TextBox1.AppendText(string.Format("{0}\n", Reader.ReadLine()));
                }
                else
                {
                    TextBox1.AppendText(string.Format("{0},", Reader.ReadLine()));
                }
                i++;
            }
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        using (StreamWriter Writer = new StreamWriter(@"C:\Original_Text_File.txt"))
        {
            using (StringReader Reader = new StringReader(TextBox1.Text))
            {
                while (!Reader.EndOfStream)
                {                
                    Writer.WriteLine(Reader.Readline());
                }
            }
        }
    }
