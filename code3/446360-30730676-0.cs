    using System.Linq;
    using System.Xml.Linq;
    
    namespace XmlBeautifier
    {
        public class XmlBeautifier
        {
            public static string BeautifyXml(string outerXml)
            {
                var _elementOriginalXml = XElement.Parse(outerXml);
                var _beautifiedXml = CloneElement(_elementOriginalXml);
                return _beautifiedXml.ToString();
            }
    
            public static XElement CloneElement(XElement element)
            {
                // http://blogs.msdn.com/b/ericwhite/archive/2009/07/08/empty-elements-and-self-closing-tags.aspx
                return new XElement(element.Name,
                    element.Attributes(),
                    element.Nodes().Select(n =>
                    {
                        XElement e = n as XElement;
                        if (e != null)
                            return CloneElement(e);
                        return n;
                    })
                );
            }
    
        }
    }
