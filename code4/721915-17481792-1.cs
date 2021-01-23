     protected void Page_Load(object sender, EventArgs e)
            {
            if(!Page.IsPostBack)
                  {
                 con = new SqlConnection("Data Source=192.168.51.71;Initial            Catalog=WebBasedNewSoft;User ID=sa;password=prabhu");
    
                BindGrid();
            }
    }
