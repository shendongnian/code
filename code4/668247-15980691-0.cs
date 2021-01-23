    StreamReader reader = new StreamReader(filetosave.ToString());
    string content = "";
    while ((content = reader.ReadLine()) != null)
    {
        if ((content == "") || (content == " "))
        { continue; }
        CKEditor1.Text += content;
        //Response.Write(content);
    }
