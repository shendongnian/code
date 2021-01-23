    const string strview = @"select MRNO,MaterialCode,Description,Specification, Category as Cat,Source as Sor,Population as Pop, StockInStores as Stock, MRRating as Rating,PreparedBy,PreparedDate,CheckedBy,CheckedDate,ApprovedBy,ApprovedDate  
                             FROM tbl_KKSMaterialRaise 
                             WHERE PreparedDate BETWEEN DateAdd(d,-1,GetDate()) AND DateAdd(d,+1,GetDate())";
    // don't use global connection objects
    using(var con = new SqlConnection(connectionString))
    using(var cmd = new SqlCommand(strview, con))
    {
        con.Open();
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
    }
