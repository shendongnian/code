    // Some example file paths
    var sourceDoc = "web.config";
    var transDoc = "web.Debug.config";
    var destDoc = "bin\web.config";
    
    // The translation at-hand
    using (var xmlDoc = new XmlTransformableDocument())
    {
      xmlDoc.PreserveWhitespace = true;
      xmlDoc.Load(sourceDoc);
    
      using (var xmlTrans = new XmlTransformation(transDoc))
      {
        if (xmlTrans.Apply(xmlDoc))
        {
          // If we made it here, sourceDoc now has transDoc's changes
          // applied. So, we're going to save the final result off to
          // destDoc.
          xmlDoc.Save(destDoc);
        }
      }
    }
