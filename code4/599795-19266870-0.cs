            DropDownTitle();
        }
    
    
    protected void DropDownTitle()
    {
        if (!Page.IsPostBack)
        {
          
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["AuzineConnection"].ConnectionString;
            
            string selectSQL = "select DISTINCT ForumTitlesID,ForumTitles from ForumTtitle";
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;
            try
            {
               
                ListItem newItem = new ListItem();
                newItem.Text = "Select";
                newItem.Value = "0";
                ForumTitleList.Items.Add(newItem);
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListItem newItem1 = new ListItem();
                    newItem1.Text = reader["ForumTitles"].ToString();
                    newItem1.Value = reader["ForumTitlesID"].ToString();
                    ForumTitleList.Items.Add(newItem1);
                }
                reader.Close();
                reader.Dispose();
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           
        }
    }
