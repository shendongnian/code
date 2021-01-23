    while(rdr.Read())
      if(rdr.NodeType == XmlNodeType.Element)
        switch(rdr.LocalName)
        {
          case "strFolder1":
            strFolder1 = rdr.ReadContentAsString();
            break;
          case "strFolder2":
            strFolder2 = rdr.ReadContentAsString();
            break;
          case "strTabName":
            strTabName = rdr.ReadContentAsString();
            break;
          case "strTabText":
            strTabText = rdr.ReadContentAsString();
            break;
        }
