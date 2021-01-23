    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Text;
    
            var dict = new Dictionary<string, string>()
            {
                 { "paragraph0", "asdflkj lksajlsakfdj laksdjf lksad jfsadf P0"},
                 { "paragraph1", " alkdsjf laksdjfla skdfja lsdkfjadsflk P1"},
                 { "paragraph2", "asdflkj lksajlsakfdj laksdjf lksad jfsadf P2"}
            };
    
            XDocument xd = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), 
                new XElement("document", 
                        dict.Where(kvp => kvp.Key.ToLower().StartsWith("paragraph"))
                            .Select(kvp => new XElement(kvp.Key, kvp.Value)),
                        new XElement("header", "etc")
                    )
                );
