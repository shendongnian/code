    //this is the class with fields.
    public class TMyClass
    {
        public String Name;
        public int old;
        public bool anx;
    }
    //this is the class with properties.
    public class TMyClass
    {
        public String Name { get; set; };
        public int old { get; set; };
        public bool anx { get; set; };
    }
    public string x(List<TMyClass> list)
    {
        TMyClass aObj;
        for(int i = 0; i++; i < list.Count)
        {
            aObj = list[i];
        }
        //NEED TO RETURN SOMETHING?
    }
