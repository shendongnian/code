    using System;
    using System.Text;
    using Microsoft.Web.Administration;
    
    internal static class Sample
    {
       private static void Main()
       {
          using (ServerManager serverManager = new ServerManager())
          {
             Configuration vDirConfig = serverManager.GetWebConfiguration("Default Web Site", "/VDir");
             ConfigurationSection staticContentSection = vDirConfig.GetSection("system.webServer/staticContent");
             ConfigurationElementCollection staticContentCollection = staticContentSection.GetCollection();
    
             ConfigurationElement mimeMapElement = staticContentCollection.CreateElement("mimeMap");
             mimeMapElement["fileExtension"] = @"bla";
             mimeMapElement["mimeType"] = @"application/blabla";
             staticContentCollection.Add(mimeMapElement);
    
             ConfigurationElement mimeMapElement1 = staticContentCollection.CreateElement("mimeMap");
             mimeMapElement1["fileExtension"] = @"tab";
             mimeMapElement1["mimeType"] = @"text/plain";
             staticContentCollection.Add(mimeMapElement1);
    
             serverManager.CommitChanges();
          }
       }
    }
