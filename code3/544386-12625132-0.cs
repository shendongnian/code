     foreach(XmlNode child in node.ChildNodes)
     {
        if (string.IsNullOrEmpty(s))
        {
            s = child.InnerText;
        }
        else
        {
            s = s.Replace(child.InnerText, "");
        }
     }
       s.Trim();
