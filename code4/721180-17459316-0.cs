        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var proxy = new Service.MyWCFServiceClient();
                customerName.DataSource = proxy.LocationGetAllRecords();
                customerName.DataTextField = "Name";
                customerName.DataValueField = "ID";
                customerName.DataBind();
                ...
            }
       }
