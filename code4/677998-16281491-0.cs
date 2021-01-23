    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Xml;
    namespace FlatFileTestCaseAutomater
    {
        class ClaimHeaderSection : IConfigurationSectionHandler
        {
            public object Create(object parent, object configContext, XmlNode section)
            {
                List<ClaimHeader> list = new List<ClaimHeader>();
                XmlNodeList claimNodeList = section.SelectNodes("claimHeader");
                foreach (XmlNode claimNode in claimNodeList)
                {
                    string name = claimNode.Attributes["name"].Value;
                    string nullable = claimNode.Attributes["nullable"].Value;
                    string dataType = claimNode.Attributes["dataType"].Value;
                    string maxLength = claimNode.Attributes["maxLength"].Value;
                    list.Add(new ClaimHeader() {Name = name, DataType = dataType, MaxLength = maxLength, Nullable = nullable});
                
                }
                return list;
            }
        }
        public class ClaimHeader
        {
            public String Name { get; set; }
            public String Nullable { get; set; }
            public String DataType { get; set; }
            public String MaxLength { get; set; }
        }
    }
