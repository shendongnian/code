     SqlConnection con = new SqlConnection("Data Source=xxx\\SQLEXPRESS;Initial Catalog=abc;Integrated Security=true;");
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.POID,p.SupplierID,p.SupplierDesc, p.CreateDate,  p.PaymentDetails,p.Status,q.Quantity,q.BalQty,q.PartNo from PoToSupplierMaster p inner join PoToSupplierMasterItems q on p.POID=q.SNO where q.PartNo='" + DropDownList3.SelectedItem.Text + "' and   p.CreateDate between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
