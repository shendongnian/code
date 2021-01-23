    Container contrainer = new Container();
    contrainer.Full = Enumerable.Range(1, 20).ToArray();
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    String str = serializer.Serialize(contrainer);
    public class Container
    {
        // don't serialize
        [ScriptIgnore]
        public Int32[] Full { get; set; }
            
        public Int32[] Partial
        {
            //select what you want to serialize
            get { return this.Full.Where(i => (i % 2) == 0).ToArray(); }
            set { this.Full = value; }
        }
    }
