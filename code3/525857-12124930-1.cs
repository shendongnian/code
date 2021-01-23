    class Info
    {
        private Func<string> getText;
        public Info(Func<string> getText)
        {
            getText = getText;
        }
        public string Text
        {
            get
            {
                return getText();
            }
        }
    }
    void Program
    {
        ClassA obj = new ClassA();
        obj.name = "Instance of ClassA";
        Info wind1 = new Info(() => obj.name);
        // Now do your stuff.
    }
