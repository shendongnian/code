    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".edmx" #>
    <#@ assembly name="System.Xml.dll" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Text" #>
    <#@ import namespace="System.Xml" #>
    <#
     var document = new XmlDocument();
     document.Load(this.Host.ResolvePath("DbContext.edmx"));
    
     var namespaceManager = new XmlNamespaceManager(document.NameTable);
     namespaceManager.AddNamespace("edmx", "http://schemas.microsoft.com/ado/2008/10/edmx");
     namespaceManager.AddNamespace("ssdl", "http://schemas.microsoft.com/ado/2009/02/edm/ssdl");
     
     var storageModelsNode = document.SelectSingleNode("//edmx:StorageModels", namespaceManager);
     
     foreach (XmlElement schemaNode in storageModelsNode.SelectNodes("ssdl:Schema", namespaceManager))
     {
         schemaNode.SetAttribute("Provider", "System.Data.SqlServerCe.4.0");
         schemaNode.SetAttribute("ProviderManifestToken", "4.0");
     
         foreach (XmlElement propertyNode in schemaNode.SelectNodes("ssdl:EntityType/ssdl:Property[@Type='varbinary(max)']", namespaceManager))
         {
             propertyNode.SetAttribute("Type", "image");
         }
    
         foreach (XmlElement propertyNode in schemaNode.SelectNodes("ssdl:EntityType/ssdl:Property[@Type='varchar']", namespaceManager))
         {
             propertyNode.SetAttribute("Type", "nvarchar");
         }
     }
    
     var stringBuilder = new StringBuilder();
     
     using (var stringWriter = new StringWriter(stringBuilder))
     using (var xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented })
     {
         document.WriteTo(xmlWriter);
     }
     
     Write(stringBuilder.ToString());
    #>
