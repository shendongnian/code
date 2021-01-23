    public class state
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    state s = new state() { A = 3, B = 6 };
    
    XmlSerializer x = new XmlSerializer(s.GetType());
    using (StreamWriter sw = new StreamWriter(@"E:\state\state.xml"))
    {
       x.Serialize(sw, s);
    }
