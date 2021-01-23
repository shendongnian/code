    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
    public interface IShelf
    {
        long Stuff { get; }
        List<IShelfItem> Items { get; }
    }
    public interface IShelfItem
    {
        string Name { get; }
		string Thought {get; set;}//What do I think about it?
    }
    public class Shelf : IShelf
    {
        public Shelf(long stuff, string color) 
        {
			Stuff = stuff;
			Items = new List<IShelfItem>();
			Color = color;
        }
        public long Stuff { get; private set; }
        public List<IShelfItem> Items { get; private set; }//Note, you can still add to the list.
		public string Color { get; set; }
    }
    public class Book : IShelfItem
    {
		public Book( string name, string thought ) {
			Name = name;
			Thought = thought;
		}
        public string Name { get; private set; }//Books that are on shelves don't really change their name;
		public string Thought { get; set; }
		
		public string BookSpecificProperty { get; set; }
    }
	
	public static void Main()
	{
		Shelf myShelf = new Shelf(42, "Dull boring grey");
		
		myShelf.Color = "Red";
		
		
		IShelf myIShelf = myShelf;
		//myIShelf.Color = "Red"; - 'IShelf' does not contain a definition for 'Color'
		
		myShelf.Items.Add( new Book("Title 1", "Such a great book" ) );
		
		//Eos pass
		
		var book = myShelf.Items.SingleOrDefault( i => i.Name == "Title 1" );
		if( book != null ) {
			book.Thought = "I used to think it was such a great book. It's just OK";
			//book.BookSpecificProperty = "X"; - 'IShelfItem' does not contain a definition for 'BookSpecificProperty'
		}
	}
