    public class MyComparer : IComparer<string>
    {
        private static readonly string[] Ratings = new [] {
            "CC","C","CCC-","CCC","CCC+",
            "B-","B","B+","BB-","BB","BB+","BBB-","BBB","BBB+",
            "A-","A","A+","AA-","AA","AA+","AAA"};
        // reverse the order so that any strings not found will be put at the end.
            
        public int Compare(string left, string right)
        {
           return Array.IndexOf(Ratings, right).CompareTo(Array.IndexOf(Ratings, left));
        }
    }
