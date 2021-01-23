    public class Ultimate
    {
        public Ultimate(XmlNode node)
        {
           XmlNode child = node.SelectSingleObject("./COL_NAM");
           if (child == null) throw new InvalidArgument("COL_NAM not found");
           Name = child.InnerText;
              
           XmlNode child = node.SelectSingleObject("./TYPE");
           if (child == null) throw new InvalidArgument("TYPE not found");
           Type = child.InnerText;
              
           XmlNode child = node.SelectSingleObject("./DEFAULT");
           if (child == null) throw new InvalidArgument("DEFAULT not found");
           Default = child.InnerText;
              
           XmlNode child = node.SelectSingleObject("./COL_NAM");
           if (child == null) throw new InvalidArgument("COL_NAM not found");
           Name = child.InnerText;
              
        }
        public string Name;
        public string Type;
        public string Value;
        public string Default;
    }
