    protected void Page_Load(object sender, EventArgs e)
       {
          if (!Page.IsPostBack)          
            SqlConnection MyConnection;
            SqlCommand MyCommand;
            SqlDataReader MyReader;
            MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConfigurationManager.ConnectionStrings["AppConnectionString1"].ConnectionString;
            MyCommand = new SqlCommand();
            MyCommand.CommandText = "SELECT TOP 10 * From PRODUCTS";
            MyCommand.CommandType = CommandType.Text;
            MyCommand.Connection = MyConnection;
            MyCommand.Connection.Open();
            MyReader = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (MyReader != null)
            {
                datalist1.DataSource = MyReader;
                datalist1.DataBind();
                pnlNew.Visible = true;
            }
            else
            {
                pnlNew.Visible = false;
            }
            MyCommand.Dispose();
            MyConnection.Dispose();
        }
    }
