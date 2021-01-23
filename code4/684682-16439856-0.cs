    class Group
    {
        private List<Group> childs;
        public Group(int arg)
        { ... }
        // pass an existing object
        public void AddSubgroup(Group g)
        {
            childs.add(g);
        }
        // or create the object inside
        public void AddSubgroup(int arg)
        {
            childs.add(new Group(arg));
        }
    }
    
    // used like this
    Group b = new Group(param);
    Group a = new Group(args);
    b.AddSubgroup(a);
