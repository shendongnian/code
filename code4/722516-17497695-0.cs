    protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
            {
            string phoneNum = "";
            cn.Open();
            SqlCommand command = new SqlCommand("getContactInfo", cn);
            command.CommandType = CommandType.StoredProcedure;
    
            SqlDataReader myReader;
            myReader = command.ExecuteReader();
    
            while (myReader.Read())
            {
                phoneNum = myReader.GetString(3).ToString();
            }
    
            cn.Close();
    
            //If I take this part out and don't populate textbox,
            //my update works.  If I leave it, it does not
            phone.Text = phoneNum.ToString();
         }
    
        }
