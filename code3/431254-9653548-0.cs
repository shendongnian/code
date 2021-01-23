        static XElement FindElementByNameAndAttr(XElement xml, XElement elem)
        {
            var q = (from x in xml.Elements()
                    where x.Name == elem.Name
                          && elem.Attributes().All(a => 
                              x.Attributes().Any(b => 
                                (a.Name == b.Name) && (a.Value == b.Value)))
                    select x)
                    .FirstOrDefault();
            return q;
        }
        static void Main(string[] args)
        {
            string xml1 =
                @"<?xml version='1.0' encoding='utf-8'?>
                <root>
                <sitegroup name = 'healthcare'>
                        <site name='A' url='a.aspx'/>
                        <site name='B' url='b.aspx'/>
                </sitegroup>
                <sitegroup name = 'diet'>
                        <site name='C' url='c.aspx'/>
                    <site name='D' url='d.aspx'/>
                </sitegroup>
                </root>
                ";
            string groupname = "jogging"; // "diet";
            string sitename = "K";
            string siteurl = "k.aspx";
            var root = XElement.Parse(xml1);
            XElement elem = new XElement("sitegroup", new XAttribute("name", groupname));
            XElement foundgroup;
            
            if((foundgroup = FindElementByNameAndAttr(root, elem)) == null)
            {
                root.Add(elem);
                foundgroup = elem;
            }
            var newsite = new XElement("site", new XAttribute("name", sitename));
            XElement foundsite;
            if ((foundsite = FindElementByNameAndAttr(foundgroup, newsite)) != null)
            {
                var attr = foundsite.Attribute("url");
                if (attr != null && attr.Value != siteurl)
                {
                    // error handling here
                    throw new Exception("TODO");
                }
            }
            else
            {
                foundgroup.Add(newsite);
                foundsite = newsite;
            }
                
            foundsite.SetAttributeValue("url", siteurl);
            Console.WriteLine(root.ToString());
        }
