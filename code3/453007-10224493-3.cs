    string file = Path.Combine(Request.PhysicalApplicationPath, "comic.xml");
    if(File.Exists(file))
    {
        myXmlDocument.Load(file);
        XmlNode rootNode = myXmlDocument.DocumentElement;
        if(rootNode !=null && rootNode.ChildNodes.Count> intComicID)
        {
           GrabComic = rootNode.ChildNodes[intComicID - 1];
                if (GrabComic == null)
                {// invalid id
                    lblOutput.Visible = true;
                    lblOutput.Text = "item doesn't exist.";
                }
                else
                {// valid id
                    pnlEdit.Visible = true;
                    txtTitle.Text = GrabComic.ChildNodes[0].InnerText;
                    txtIssue.Text = GrabComic.ChildNodes[1].InnerText;
                    txtDesc.Text = GrabComic.ChildNodes[2].InnerText;
                }
        }
    
    }
