    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int imageID = Convert.ToInt32(e.CommandArgument);
            string constring = @"Server=User-PC\SQLEXPRESS;initial catalog=Student;Integrated Security=true";
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            string query="Delete from [student].[dbo].[ImageTable] where ID=" +imageID;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.LoadGrid();
            conn.Close();
           
        }
    }
