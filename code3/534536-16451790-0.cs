    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    var xDocument = XDocument.Load (infoPlist);
    // Do your manipulations here
    xDocument.Save (infoPlist);
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load (infoPlist);
    if (xmlDocument.DocumentType != null)
    {
        var name = xmlDocument.DocumentType.Name;
        var publicId = xmlDocument.DocumentType.PublicId;
        var systemId = xmlDocument.DocumentType.SystemId;
        var parent = xmlDocument.DocumentType.ParentNode;
        var documentTypeWithNullInternalSubset = xmlDocument.CreateDocumentType(name, publicId, systemId, null);
        parent.ReplaceChild(documentTypeWithNullInternalSubset, xmlDocument.DocumentType);
    }
    xmlDocument.Save (infoPlist);
