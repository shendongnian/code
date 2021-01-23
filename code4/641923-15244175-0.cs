    protected void Page_Load(object sender, EventArgs e)
    {
       config = new Config();
       string file = @"C:\Config.xml";
       XmlData xmlData = new XmlData(file);
       config = xmlData.Deserialize();
    
      if (!Page.IsPostBack)
       { 
           StoreCustomers.DataSource = config.Customers;
           StoreCustomers.DataBind();
        }
    }
