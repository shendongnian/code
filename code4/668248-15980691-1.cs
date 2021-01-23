    string content;
    string line;
    using (StreamReader reader = new StreamReader(filetosave.ToString())
    {
        while ((line= reader.ReadLine()) != null) 
        {
            content += line;
        }
    }
    CKEditor1.Text = content;
