    List<XmlInfo> GridValues = Grid_Values(); 
    foreach (XmlInfo item in GridValues) 
    { 
         writer.WriteStartElement("Cell"); 
         writer.WriteAttributeString("Status", item.value); 
         writer.WriteAttributeString("XLoc", item.column); 
         writer.WriteAttributeString("YLoc", item.row); 
         writer.WriteEndElement(); 
    }
