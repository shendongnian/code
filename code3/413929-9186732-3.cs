    public class Child
    {
        [XmlIgnore]
        public Parent MyParent;
        public Child(Parent parent)
        {
            MyParent = parent;
        }
    }
