    if (File.Exists(curFile))
    {
        System.IO.StreamReader file = new System.IO.StreamReader(curFile);
        while ((contents = file.ReadLine()) != null)
        {
            dataElm.InnerText = contents;
            xdoc.DocumentElement.AppendChild(dataElm);
        }
    }
    else 
    {
        // log statement that file curFile was not found
    }
