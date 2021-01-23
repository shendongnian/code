    StringWriter wr = new StringWriter();
    var r = new System.Web.Services.Description.ServiceDescriptionReflector();
    r.Reflect(type, "http://somewhere.com");
    r.ServiceDescriptions[0].Write(wr);
    var wsdl = wr.ToString();
