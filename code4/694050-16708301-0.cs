    public partial class MasterDetails : Form
        {
            GridControl grid;
            GridView view;
            GridView detailView;
            GridLevelNode detailNode;        
            public MasterDetails()
            {
                InitializeComponent();            
                InitializeGrid();
                InitializeAndAddColumnsToViews();
                InitializeAndBindDataSource();
            }
    
            private void InitializeGrid()
            {
                grid = new GridControl();
                view = new GridView(grid);
                detailView = new GridView(grid);
                detailNode = grid.LevelTree.Nodes.Add("SuppliersProducts", detailView);
                grid.Dock = DockStyle.Fill;
                this.Controls.Add(grid);
            }
            private void InitializeAndAddColumnsToViews()
            {
                if (view != null && detailView != null)
                {
                    view.Columns.AddField("CategoryID").VisibleIndex = 0;              
    
                    detailView.Columns.AddField("ID").VisibleIndex = 0;
                    detailView.Columns.AddField("Name").VisibleIndex = 1;
                    detailView.Columns.AddField("Category").VisibleIndex = 2;
                }
            }
    
            private void InitializeAndBindDataSource()
            {
                List<BookDetail> bookDetails = new List<BookDetail>();
    
                BookDetail bookDetail = null;
                for (int j = 0; j < 5; j++)
                {
                    bookDetail = new BookDetail { CategoryID = j + 1 };
                    for (int i = 0; i < 5; i++)
                    {
                        bookDetail.Books.Add(new Book
                        {
                            ID = 1,
                            Name = "Book - " + (i + 1),
                            Category = j + 1
                        });
                    }
                    bookDetails.Add(bookDetail); 
                }
                grid.DataSource = bookDetails;
            }
        }
