    public class MyObject
    {
        public string first
        {
            get;
            set;
        }
        public string second
        {
            get;
            set;
        }
        public MyObject DeepClone()
        {
            return new MyObject{ first = this.first, second = this.second;}
        }
    }
    // Then you can do this:
    List<MyObject> list = new List<MyObject>();
    list.Add(new MyObject{first = "one", second = "two"});
    list.Add(new MyObject{first = "here", second = "there"});
    list.Add(new MyObject{first = "car", second = "plane"});
    list.Add(list[list.Count-1].DeepClone());        
