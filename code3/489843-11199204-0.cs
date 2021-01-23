     using (JavascriptContext context = new JavascriptContext())
      {
        context.SetParameter("data", new MyObject());
      
         StringBuilder s = new StringBuilder();
        foreach (XPathNavigator nav in scriptTags)
        {
           s.Append(nav.InnerXml);
        }
      s.Append(";data.item = itemCol;");
      context.Run(s.ToString());
      MyObject o = context.GetParameter("data") as MyObject;
