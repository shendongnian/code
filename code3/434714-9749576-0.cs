    public class MyNodeData
    {
        public MyNodeData()
        {
            Children = new LinkedList<MyNodeData>();
        }
        public MyNodeData(int i, string s)
            : this()
        {
            MyInt = i;
            MyString = s;
        }
        public int MyInt { get; set; }
        public string MyString { get; set; }
        public LinkedList<MyNodeData> Children { get; private set; }
    }
