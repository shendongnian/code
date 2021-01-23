    private static Document ParseDocument(XmlReader xr)
    {
      using(xr)
      {
        Document doc = new Document();
        while(xr.Read())
          if(xr.NodeType == XmlNodeType.Element)
            if(xr.GetAttribute("id") == "customer")
              doc.Customer = ParseCustomer(xr.ReadSubtree());
            else
              switch(xr.GetAttribute("name"))
              {
                case "somemoredata1":
                  doc.SomeMoreData1 = int.Parse(xr.GetAttribute("value"));
                  break;
                case "somemoredata2":
                  doc.SomeMoreData2 = xr.GetAttribute("value");
                  break;
              }
          //Put some validation of doc here if necessary.
          return doc;
      }
    }
    private static Customer ParseCustomer(XmlReader xr)
    {
      Customer cu = new Customer();
      while(xr.Read())
        if(xr.NodeType == XmlNodeType.Element)
          if(xr.GetAttribute("id") == "address")
            cu.Address = ParseAddress(xr.ReadSubtree());
          else
            switch(xr.GetAttribute("name"))
            {
              case "firstname":
                cu.FirstName = xr.GetAttribute("value");
                break;
              case "lastname":
                cu.LastName = xr.GetAttribute("value");
                break;
            }
        //validate here if necessary.
        return cu;
    }
    private static Address ParseAddress(XmlReader xr)
    {
      Address add = new Address();
      while(xr.Read())
        if(xr.NodeType == XmlNodeType.Element)
          switch(xr.GetAttribute("name"))
          {
            case "city":
              add.City = xr.GetAttribute("value");
              break;
            case "country":
              add.Country = xr.GetAttribute("value");
              break;
          }
      return add;
    }
