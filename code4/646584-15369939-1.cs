    List<string> datalinestream = new List<string>();
    string fileName;
    
    using(FileDialog FD = new System.Windows.Forms.OpenFileDialog())
    {
        if(FD.ShowDialog() == DialogResult.OK)
            fileName = FD.FileName;
        else
            return;
    }
    
    TextReader reader = new StreamReader(fileName);
    using (reader)
    {
        string line = "";
        while ((line = reader.ReadLine()) != null)
        {
    
            while (reader.Read() != '\r')
            {
                datalinestream.Add(GetWord(reader));
            }
            LuceneDB.AddUpdateLuceneIndex(new MATS_Doc( datalinestream));
            datalinestream.Clear();
        }
    }
