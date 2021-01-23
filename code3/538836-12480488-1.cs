	public class ForYourGrid
	{
		public int BorrowerID { get; set; }
		public string BorrowerName { get; set; }
    ...
	}
    
		var query2 = from b in ctx.books 
					... 
					select new ForYourGrid 
					{ BorrowerID = b.ID, BorrowerName = b.Name , ... 
					}
		var selected = this.borrowedBookList.selectedItem as ForYourGrid;
		var selectedTran = ctx.Transactions.SingleOrDefault(e => e.TransactionID == selected.TransactionID);
		selectedTran.isReturned = "YES";
		var selectedBook = ctx.Books.SingleOrDefault(e => e.BookID == selected.BookID);
		selectedBook.CopyLeft++;
    
        ctx.SaveChanges();
