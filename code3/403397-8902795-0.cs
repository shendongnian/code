    if (reader.Name == "rect" || reader.Name == "polygon")
    {
        // get tag name here
        var tagName = reader.Name;
        while(reader.MoveToNextAttribute()){
            if(reader.Name == "fill" && reader.value == "none"){
                // write tag name here
                writer.WriteStartElement(tagName);
                writer.WriteAttributes(reader, true);
                writer.WriteEndElement();
            }
        }
    }
