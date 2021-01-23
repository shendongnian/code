    using System;
    using System.Linq;
    using System.Text;
   
    using System.Xml;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var xml = @"<entry><AUTHOR>C. Qiao</AUTHOR> and <AUTHOR>R.Melhem</AUTHOR>, ""<TITLE>Reducing Communication </TITLE>"",<DATE>1995</DATE>. </entry>";
            var elem = XElement.Parse(xml);
            var tokFunc = new Func<XNode, string>(node =>
                {
                    var s = node.ToString().Replace(".", " . ").Replace(",", " , ");
                    var nodeName = node.Parent != null && 
                        node.Parent.NodeType == XmlNodeType.Element && 
                        node.Parent.Name.LocalName.ToUpper() != "ENTRY"
                                       ? node.Parent.Name.LocalName
                                       : "";
                    var sb = new StringBuilder();
                    s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(e => sb.AppendFormat("{0}\t{1}\n", e, nodeName));
                    return sb.ToString();
                });
            
            elem.DescendantNodes().Where(e => e.NodeType == XmlNodeType.Text).ToList()
                .ForEach(c => Console.Write(tokFunc(c)));
        }
    }
