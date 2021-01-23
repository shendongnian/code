    protected void Page_Load(object sender, EventArgs e)
    {
        List<Category> _lstCategory = new List<Category>{new Category { CatID = 1, CatName = "Cat1" }, 
                                                            new Category { CatID=2,CatName="Cat2" }};
        //GridView1.CellPadding = 20;
        //GridView1.RowStyle.Height = 80;
        GridView1.DataSource = _lstCategory;
        GridView1.DataBind();
    }
    public class Category
    {
        public int CatID { get; set; }
        public string CatName { get; set; }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Width = 100;
        e.Row.Cells[0].Width = 1;
    }
