    con.Open();
    string str = DropDownList1.SelectedValue;
    SqlDataAdapter da = new SqlDataAdapter("select distinct a.DepotCode,a.CustWt, b.CustName,b.Lat_Degree,b.Lat_Minute,b.Lat_Second,b.Lon_Degree,b.Lon_Minute,b.Lon_Second from tblDepotCustMapping a, tblCustomers b where DepotCode='" + str + "'and a.CustCode=b.CustCode", con);
    DataSet ds = new DataSet();
    da.Fill(ds);
    GridView1.DataSource = ds;
    GridView1.DataBind();
    con.Close();
