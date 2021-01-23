        public static void Main()
        {
            var likeListDict = new Dictionary<int, List<string>>();
            var lists = new List<string> {"hello", "world"};
            likeListDict.Add(1, lists);
            var secondList = new List<string> {"foobar"};
            likeListDict.Add(2, secondList); 
        }
