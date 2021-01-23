    using System.Xml.XPath;
    ...
    
    void foo(){
        XDocument document = XDocument.Load("People.xml");
        
        var firstCustomerNode = document.XPathSelectElement(
            "/customers/customer[0]/name"
            );
        var hasfirstNameAndLastName = firstCustomerNode.Attribute("firstname") != null && firstCustomerNode.Attribute("lastname");
        
        if(hasfirstNameAndLastName)
        {
        
        }
    }
