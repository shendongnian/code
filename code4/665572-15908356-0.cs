    var values = new List<string>();
    var collectValues = false;
    var desiredChannelId = "5154131";
    while (reader.Read())
    {
         if((reader.NodeType == XmlNodeType.Element))
         {
             if (reader.Name == "ChannelID" && reader.HasAttributes) {
                 collectValues = reader.GetAttribute("EndPointChannelID") == desiredChannelId;
             }
             else if (collectValues && reader.Name == "Reading" && reader.HasAttributes)
             {
                  values.Add(reader.GetAttribute("Value"));
             }
          }
    }
