bool skipRead = false;
while (skipRead || reader.Read())
{
     skipRead = false;
     if (reader.NodeType == XmlNodeType.Element)                    
         element = reader.Name;  
     else if (reader.NodeType == XmlNodeType.Text)
     {
         if (element == "column")
         {
             if (Reader.Read())
             {
               if(reader.NodeType == XmlNodeType.Element && reader.Name == "Size")
               {
                   // do whatever you need to here with reader.Value. 
                   // E.g size = (int) reader.Value
                   skipRead = false;
                   continue;
               } // Additional ifs for other elements in column can go here.
               else
               {
                   skipRead = true;
                   continue;
               }
             }
             else
             {
              break;
             }
         }
     }
}
