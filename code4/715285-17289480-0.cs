    public abstract partial class Book
    {
      public Book()
      {
        this.Orders = new HashSet<Order>();
      }
      //other properties of yours go here
      //--------------------------------
      //---------------------------------
      public string BookInfo {
           get {
              return this.Title + "\t" + this.Year + "\t" + this.Price + "\t" + this.Quantity + "\t" + this.GetType();
           }
      }
    }
    //Then you can bind your list to your DataGridView like this
    DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn(){Name = "NewColumn", DataPropertyName="BookInfo"};//Notice the BookInfo which is assigned as the DataPropertyName for your new column.
    dataBooks.Columns.Add(newColumn);
    dataBooks.DataSource = _Author.Books.ToList();
    
