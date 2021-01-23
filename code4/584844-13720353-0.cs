     protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string connStr = @"Data Source=MY-PC\SQLExpress;Initial Catalog=DataDB;User Id=ME;Password=YourPassword;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "Select MenuID, Text,Description, ParentID from UserInfo";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds);
                da.Dispose();
            }
            ds.DataSetName = "UserInfos"; //You can start directly from here as you have the dataset just mantain Parent and Child ID Proper
            ds.Tables[0].TableName = "UserInfo";
            DataRelation relation = new DataRelation("ParentChild",
             ds.Tables["UserInfo"].Columns["MenuID"],
             ds.Tables["UserInfo"].Columns["ParentID"], true);
            relation.Nested = true;
            ds.Relations.Add(relation);  //XmlDataSource1 is any source of xml you can have this in file also
            XmlDataSource1.Data = ds.GetXml(); //Here Dataset will automatically generate XML for u based on relations added
            
        }
