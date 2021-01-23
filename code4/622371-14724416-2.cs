    public partial class GridTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            var source = GetCarTable().Select("", this.SortExpression).CopyToDataTable();
            GridCar.DataSource = source;
            GridCar.DataBind();
        }
        private string SortExpression
        {
            get
            {
                if (ViewState["SortExpression"] == null || string.IsNullOrEmpty((String)ViewState["SortExpression"]))
                {
                    ViewState["SortExpression"] = "CarModel ASC";
                }
                return ViewState["SortExpression"].ToString();
            }
            set { ViewState["SortExpression"] = value; }
        }
        private static DataTable GetCarTable()
        {
            DataTable carsTable = new DataTable("cars");
            carsTable.Columns.Add("CarID");
            carsTable.Columns.Add("CarRegNum");
            carsTable.Columns.Add("CarModel");
            carsTable.Columns.Add("CarType");
            carsTable.Columns.Add("CarOwner");
            carsTable.Rows.Add(1, "AAA-111", "Toyota", "Hatchback", "Matti");
            carsTable.Rows.Add(2, "BBB-222", "Mercedes-Benz", "Van", "Keijo");
            carsTable.Rows.Add(3, "CCC-333", "Renault", "Regular", "Matilda");
            return carsTable;
        }
        protected void gridCar_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
        {
            string currentSortColumn = null;
            string currentSortDirection = null;
            currentSortColumn = this.SortExpression.Split(' ')[0];
            currentSortDirection = this.SortExpression.Split(' ')[1];
            if (e.SortExpression.Equals(currentSortColumn))
            {
                //switch sort direction
                switch (currentSortDirection.ToUpper())
                {
                    case "ASC":
                        this.SortExpression = currentSortColumn + " DESC";
                        break;
                    case "DESC":
                        this.SortExpression = currentSortColumn + " ASC";
                        break;
                }
            }
            else
            {
                this.SortExpression = e.SortExpression + " ASC";
            }
            //load the data with this SortExpression and DataBind the Grid
            BindGrid();
        }
        protected void GridCar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridCar.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void GridCar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridCar.EditIndex = -1;
            BindGrid();
        }
        protected void GridCar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var oldValues = e.OldValues;
            var newValues = e.NewValues;
            // BindGrid();
        }
        protected void GridCar_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //BindGrid();
        }
    }
