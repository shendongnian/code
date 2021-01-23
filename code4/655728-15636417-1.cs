    [Serializable]
    public class Actions
    {
        [XmlElementAttribute("Walked", typeof(WalkedAction))]
        [XmlElementAttribute("Cycled", typeof(CycledAction))]
        public List<Action> ActionList { get; set; }
    }
    [Serializable]
    public abstract class Action
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
    [Serializable]
    public class WalkedAction : Action
    {
        [XmlAttribute]
        public int Distance { get; set; }
    }
    [Serializable]
    public class CycledAction : Action
    {
        [XmlAttribute]
        public string Gear { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var actionList = new Actions();
            actionList.ActionList = new List<Action>();
            actionList.ActionList.Add(new WalkedAction { Name = "Bob", Distance = 4 });
            actionList.ActionList.Add(new CycledAction { Name = "Jane", Gear = "3rd" });
            var ser = new XmlSerializer(typeof(Actions));
            TextWriter w = new StringWriter();
            ser.Serialize(w, actionList);
            TextReader r = new StringReader(w.ToString());
            Actions result = (Actions) ser.Deserialize(r);
        }
    }
 
