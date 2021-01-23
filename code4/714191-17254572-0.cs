    XmlDocument version = new XmlDocument();
    version.Load(path);
    
    foreach (XmlNode node in version.ChildNodes[0].ChildNodes)
    {
        if (node.Name == "Version")
            MessageBox.Show("Version: " + node.InnerText);
        else if (node.Name == "Lastfix")
            MessageBox.Show("LastFix: " + node.InnerText);
    }
