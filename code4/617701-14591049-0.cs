    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", 
        RequestNamespace="http://xxx", ResponseNamespace="http://xxx", 
        Use=System.Web.Services.Description.SoapBindingUse.Literal,
        ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    [return: System.Xml.Serialization.XmlElementAttribute("return", 
        Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    number[] getNumbersForUser(
        [System.Xml.Serialization.XmlElementAttribute(
            Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] long foreignId, 
        [System.Xml.Serialization.XmlElementAttribute(
            Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] long userId);
