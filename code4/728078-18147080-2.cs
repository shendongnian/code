    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace xmlTesting
    {
      public class codeList
      {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
      }
    
      class program {
    
        static void Main(string[] args)
        {
          var CL = UploadXml(XElement.Load(@"c:\debug\xmlcontent.xml"));
          Console.WriteLine(
            string.Format("name: {0}\nDesc: {1}\nVersion: {2}\nEffectivdate: {3}\nExp: {4}"
            , CL.Name, CL.Description, CL.Version, CL.EffectiveDate, CL.ExpirationDate)
            );
          Console.ReadKey(true);
        }
    
        public static codeList UploadXml(XElement xdoc)
        {
          var codeList = new codeList();
    
          foreach (XElement XE in xdoc.Descendants())
          {
            switch (XE.Name.LocalName)
            {
              case "CODELIST_NAME":
                codeList.Name = XE.Value;
                break;
              case "DESCRIPTION":
                if(codeList.Description == null)
                codeList.Description = XE.Value;
                break;
              case "VERSION":
                codeList.Version = XE.Value;
                break;
              case "EFFECTIVE_DATE":
                codeList.EffectiveDate = DateTime.Parse(XE.Value);
                break;
              case "EXPIRATION_DATE":
                codeList.ExpirationDate = DateTime.Parse( XE.Value);
                break;
            }
          }
          // save code list
    
          // get code list ID
    
          // create codes
          return codeList;
        }
      }
    }
