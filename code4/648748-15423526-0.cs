       protected void Button1_Click(object sender, EventArgs e)
    {
       if (DropDownList1.SelectedItem.ToString() =="ER00 - File Header")
        {
            using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["DBcon"]))
            {
                if (String.IsNullOrEmpty(TextBox_ID.Text.ToString()))
                {
                    lbl_NoBatchID.Text = "Please enter BatchID!";
                }
                else
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand("Select * from tbl_WinApps_FileHeader Where BatchID =" + TextBox_ID.Text.ToString());
                        sqlCommand.Connection = con;
                        con.Open();
                        SqlDataReader read = sqlCommand.ExecuteReader();
                            GridView1.DataSource = read;
                            GridView1.DataBind();
                        lbl_NoBatchID.Text = "";
                    }
                    catch (Exception)
                    {                           
                    }
                }
            }
        }
