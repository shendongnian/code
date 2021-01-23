     string brandName = "xyz";
     string ballName = "ball A";
     var brands = doc.Elements("Brand").Where(s => s.Attribute("name").Value == brandName);
     foreach (var brand in brands)
     {
         if(brand.Elements("BallName").Any(l => l.Value == ballName))
         {
             brand.Remove();
         }
     }
