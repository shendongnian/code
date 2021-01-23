    public class XSystem
    {
       public XSystem(XElement xSystem) { self = xSystem; }
       XElement self;
    
       public int Id { get { return (int)self.Element("ID"); } }
       public string Name { get { return self.Element("NAME").Value; } }
       public int SystemSetting { get { return (int)self.Element("SystemSetting"); } }
       public int SystemSettingCS { get { return (int)self.Element("SystemSettingCS"); } }
    }
