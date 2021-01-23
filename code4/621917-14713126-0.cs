    using System.IO;
    //...
    StringWriter writer = new StringWriter();
    dsApprovers.WriteXml(writer);
    string xmlResult = writer.ToString();
