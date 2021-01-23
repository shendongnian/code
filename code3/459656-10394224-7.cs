    public static class Extensions
    {
        static Random rand = new Random();
        public static int randomOne(this List<int> theList)
        {
            return theList[rand.Next(0, theList.Count)];
        }
    }
