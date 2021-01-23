    public static class Extensions
    {
        public static int randomOne(this List<int> theList)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            return theList[rand.Next(0, theList.Count)];
        }
    }
