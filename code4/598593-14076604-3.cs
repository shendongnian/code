    private void button2_Click(object sender, EventArgs e)
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Original_Text_File.txt"))
        {
            writer.Write(builder.ToString());
        }
    }
   
