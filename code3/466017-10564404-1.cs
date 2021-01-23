    ///Reference the namespace
    using System.Xml.Linq;
    try
    { 
        ///Read xml from url
        var doc = XDocument.Load("MyUrl");
        ///Write it to local file
        doc.Save("MyFile.xml");
    }
    catch(Exception exception)
    {
        MessageBox.Show(exception.Message);
    }
