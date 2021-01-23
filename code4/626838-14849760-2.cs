    XmlDocument doc = new XmlDocument();
    doc.Load("Data.xml");
    int count = doc.SelectNodes("Data/DataClass").Count;
    Parallel.For(0,doc.SelectNodes("Data/DataClass").Count-1,i =>
    {
        XmlNode node = doc.SelectNodes("Data/DataClass")[i];
        XmlNodeList subnode = node.ChildNodes;
        string pathO = "";
        string pathI = subnode[0].InnerText;
        string prefix = subnode[2].InnerText;
        string freq = subnode[3].InnerText;
        string[] filenames = Directory.GetFiles(pathI);
        doc.Save("Data.xml");
        foreach (var filename in filenames)
        {
            pathO = subnode[1].InnerText;
            pathO = pathO + "\\" + prefix;
            string fname = Path.GetFileName(filename);
            pathO = pathO + fname;
            System.IO.File.Move(filename, pathO);
        }
    }
    );
