     private static  object objLock = new object();
     lock(objLock)
     {
       using (XmlTextWriter textWriter = new    XmlTextWriter("E:/Sites/www.bivolino.com/bivolino3D/bivo/imgGal/ProductFeedBeslist.xml", Encoding.UTF8))
        {
           textWriter.WriteStartDocument();
           xProducts.Save(textWriter);
           textWriter.WriteEndDocument();
           textWriter.Close();
          
         }
     }
   
  
  
