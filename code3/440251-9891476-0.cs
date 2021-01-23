	public class Bookmark
	{
		public int ID { get; set; }
		public int Start { get; set; }
		public int End { get; set; }
	}
        // setting up your bookmark indices
        const int NumBookmarks = 200;
        Bookmark[] startIndices = new Bookmark[NumBookmarks];
        Bookmark[] endIndices = new Bookmark[NumBookmarks];
        // add a new bookmark
        Bookmark myBookmark = new Bookmark(){ID=5, Start=10, End=30};
        startIndices[myBookmark.Start] = myBookmark;
        endIndices[myBookmark.End] = myBookmark;
        // get a bookmark
        Bookmark myBookmark = startIndices[10];
        
