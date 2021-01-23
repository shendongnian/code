    public void OnApplyButtonClick(object sender, EvenArgs e)
    {
    this.ApplyBtn.Enabled = false;
    //Your logic Here
    }
    public void xmlwriter(string path)
            {
    btnApply.Enabled = false;
                XmlDocument xdoc = new XmlDocument();                
                xdoc.Load("C:\\product.txt);
                XmlNode fold = xdoc.CreateElement("Folder");
                XmlNode name = xdoc.CreateElement("Name");
                XmlNode rec = xdoc.CreateElement("Recurse");
                name.InnerText = path;
                rec.InnerText = "true";
                fold.AppendChild(name);
                fold.AppendChild(rec);
                xdoc.SelectSingleNode("//Folders").AppendChild(fold);
                xdoc.Save("C:\\product.txt");
    btnApply.Enabled = true;
            }
    public void DeleteNode(string snode)
            {
    this.ApplyBtn.Enabled = false;
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load("C:\\product.txt");
                foreach (XmlNode node in xdoc.SelectNodes("BackupProfile/Folders/Folder"))
                {
                    string temp = node.SelectSingleNode("Name").InnerText;
                    if (temp == snode)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                }
                xdoc.Save("C:\\product.txt");
    this.ApplyBtn.Enabled = true;
        }
