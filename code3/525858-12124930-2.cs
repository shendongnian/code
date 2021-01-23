    class Info
    {
        public Info(ClassA obj)
        {
            TheObject = obj;
        }
        public ClassA TheObject
        {
            get;
            set;
        }
        public string Text
        {
            get
            {
                return TheObject.name;
            }
        }
    }
    void Program
    {
        ClassA obj = new ClassA();
        obj.name = "Instance of ClassA";
        Info wind1 = new Info(obj);
        // Now do your stuff.
    }
