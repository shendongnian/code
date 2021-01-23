    public class  Data
    {
        public decimal Hours { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = new List<Data>
            {
                new Data { Hours = 6.25m, Notes = "One", Date = DateTime.Parse("07/11/2013")},
                new Data { Hours = 3m, Notes = "Two", Date = DateTime.Parse("07/11/2013")},
                new Data { Hours = 5m, Notes = "Three", Date = DateTime.Parse("07/11/2013")},
                new Data { Hours = 4m, Notes = "Four", Date = DateTime.Parse("01/01/1900")}
            };
        GridView1.DataBind();
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {         
            var data = e.Row.DataItem as Data; 
            var date = data.Date;
            // Cast to DataRowView if your datasource is DataTable or DataSet
            // var rowView = (DataRowView)e.Row.DataItem;
        }
    }
