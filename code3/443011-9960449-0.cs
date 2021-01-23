    class SomeClass
    {
        Dictionary<string, int[]> myDictionary = new Dictionary<string, int[]>()
        {
            {"length", new int[] {1,1} },
            {"width", new int[] {1,1} },
        };
        public void SomeMethod()
        {
            Dictionary<string, int[]> myDictionary2;
            myDictionary2 = new Dictionary<string, int[]>()
            {
                {"length", new int[] {1,1} },
                {"width", new int[] {1,1} },
            };
        }
    }
