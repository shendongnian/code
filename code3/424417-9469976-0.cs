    protected void Page_Load(object sender, EventArgs e) 
    { 
        If(!Page.IsPostBack)
        {
            ddlCars.Items.Add("Ford"); 
            ddlCars.Items.Add("Chevy"); 
            ddlCars.Items.Add("BMW"); 
            ddlCars.Items.Add("Jeep"); 
            ddlCars.Items.Add("Nissan"); 
        }
    }
