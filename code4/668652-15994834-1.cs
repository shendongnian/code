    System.IO.FileStream fs = 
                        new System.IO.FileStream(Saved_File,
                            System.IO.FileMode.OpenOrCreate,System.IO.FileAccess.ReadWrite);
        richTextBox1.SaveFile(fs, Saved_File);
            richTextBox2.SaveFile(fs, Saved_File);
            richTextBox3.SaveFile(fs, Saved_File);
            richTextBox53.SaveFile(fs, Saved_File);
    fs.Close();
