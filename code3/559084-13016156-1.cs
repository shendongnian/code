    using (TextWriter writer = new StreamWriter(File.Create("TableDoc.txt")))
    {
        XDocument doc=XDocument.Load("yourXML");//load document
        foreach(var elm in doc.Descendants("Table"))//takes all table elements
        {
        string s="The table-"+elm.Element("TableName").Value+"- has coloumns -"+elm.Element("Columns").Value;
          writer.WriteLine(s);
        }
    }
