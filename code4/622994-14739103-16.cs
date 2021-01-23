    public static class A
    {
        // please note: some example in related to your question
        // and the strategy pattern provided at the link
        public static P GetI(int a)
        {
            if (a == 1)
                return new I();
            else
                return null; // <- this is important for evaluation
        }
        // can put this method anywhere else, also into another class
        public static P GetO(int a)
        {
            if (a == 2)
                return new O();
            else
                return null; // <- this is important for evaluation
        }
        public static bool Condition(string pci)
        {
            return !string.IsNullOrEmpty(pci); // could eval different states, values
        }
    }
