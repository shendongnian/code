        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MyLinqToSqlDataContext db = new MyLinqToSqlDataContext();
                var result = from c in db.Customers
                             select g;
                customerName.DataSource = result.ToList();
                customerName.DataTextField = "Name";
                customerName.DataValueField = "ID";
                customerName.DataBind();
                ...
            }
       }
