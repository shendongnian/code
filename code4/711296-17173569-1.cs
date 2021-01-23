    //Get the root node.
    XmlElement root = xmlDocument.DocumentElement;
    //Get the "Purchased-Assets" node that is nested inside the root.
    XmlElement assets = root["Purchased-Assets"];
    //Loop though each child
    foreach(XmlNode childAsset in assets.ChildNodes)
    {
         //Find the "ID" element of the child, you could easily replace this
         //to find the "Name" element.
         XmlElement id = childAsset["ID"];
         //If there is an "ID" element
         if(id != null)
         {
             //if the id node of the current child equals "20"
             if(id.InnerText.Equals("20"))
             {
                  //then remove the asset from the "Purchased-Assets" node
                  assets.RemoveChild(childAsset);
             }
         }
    }
