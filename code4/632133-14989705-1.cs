    var allObjs = new Dictionary<string, MyObj>();   
    
    
    foreach (XmlNode nodes in node.ChildNodes)
    {
      var obj = new MyObj();
        if (nodes.Name == "DEFAULT")
          obj.Default = nodes.InnerText;
        ...
        allObjs.Add(obj.Name, obj);
    }
