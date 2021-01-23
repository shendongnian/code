        string sql = "Update Business SET Name=@Name, ContactName=@ContactName, Address=@Address WHERE BusinessID=@BusinessID AND Status='A';";
        System.Data.SqlClient.SqlParameter[] par = new System.Data.SqlClient.SqlParameter[4];
        par[0] = new System.Data.SqlClient.SqlParameter("@Name", txtBusName.Text);
        par[1] = new System.Data.SqlClient.SqlParameter("@ContactName", txtContName.Text);
        par[2] = new System.Data.SqlClient.SqlParameter("@Address", txtAddr1.Text);
        par[3] = new System.Data.SqlClient.SqlParameter("@BusinessID", busID);
            System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand(sql, SQL_CONNECTION);
            com.Parameters.AddRange(par);
            com.ExecuteNonQuery();
