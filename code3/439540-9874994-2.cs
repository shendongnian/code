    XmlDocument xdoc = new XmlDocument();
    xdoc.Load(filename);
    XmlNode root = xdoc.DocumentElement;
    
        //Display the contents of the child nodes.
        if (root.HasChildNodes)
        {
          for (int i=0; i<root.ChildNodes.Count; i++)
          {
            richTextBox1.AppendText(root.ChildNodes[i].InnerText+"\n");
          }
        }
