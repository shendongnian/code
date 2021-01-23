    protected void GVProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    //your code
    
     if (!abort)
        {
            connection = new Connect(Server.MapPath("App_Data/ado1.mdb"));
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "Update Products Set amount=" + amount + ", minAmount=" + minAmount + " Where phoneId=" + id;
            cmd.ExecuteNonQuery();//OR "connection.ChangeDatabase(cmd);" if it updates your database
            products = connection.GetData("Select * From Products", "Products");
            GVProducts.EditIndex = -1;
            GVProducts.DataSource = products;
            GVProducts.DataBind();
            UpdateGVlabel();
    
            MessageBox.Show("המכשיר נערך בהצלחה!");
        }
    }
