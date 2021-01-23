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
