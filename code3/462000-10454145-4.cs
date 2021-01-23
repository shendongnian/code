    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    private static IEnumerable<Window> ReadWindows(string path)
    {
        XDocument doc = XDocument.Load(path);
        return from w in doc.Root.Elements("window")
               select new Window((int)w.Attribute("ID"))
               {
                   ParentID = (int?)w.Element("parentID"),
                   Type = (string)w.Element("windowType"),
                   Name = (string)w.Element("windowName"),
                   Text = (string)w.Element("windowText"),
                   Options = (string)w.Element("windowOptions"),
                   Actions = (string)w.Element("windowActions"),
                   Exit = (string)w.Element("windowExit"),
               };
    }
