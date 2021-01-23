    public partial class Form1 : Form
    {
        private Dictionary<String, Module> modules;
        public Form1()
        {
            this.modules = LoadXml(XDocument.Load(xmlPath);
        }
        private Dictionary<String, Module> LoadXml(XDocument doc)
        {
            return (from elem in doc.Root.Descendants("Module")
                           select new Module()
                           {
                               Name = elem.Element("Name").Value, 
                               Code = elem.Element("Code").Value, 
                               Capacity = elem.Element("Capacity").Value, 
                               Semester = elem.Element("Semester").Value, 
                               Prerequisite = elem.Element("Prerequisite").Value, 
                           }).ToDictionary(k=>k.Name, v=>v);            
        }
    }
