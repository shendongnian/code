        public string myParam { get; set; }
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_CustomerCode.DataSource = OrderDefinitionData.GetCustomers(myParam);
                ddl_CustomerCode.DataTextField = "CustomerCode";
                ddl_CustomerCode.DataValueField = "CustomerName";                
                ddl_CustomerCode.DataBind();
             }
        }
