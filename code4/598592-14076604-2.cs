    private void button1_Click(object sender, EventArgs e)
    {
        using (StreamReader reader = new StreamReader(@"C:\Original_Text_File.txt"))
        {
            StringBuilder builder = new StringBuilder();
            while (reader.Peek() >= 0) 
            {
                builder.AppendLine(reader.ReadLine());
            }
        }
    }
