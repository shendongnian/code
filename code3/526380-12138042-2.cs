    SqlParameter[] param= new SqlParameter[1];
    
    param[0] = new SqlParameter("@Vendor_ID", 0);
    param[0].Direction = ParameterDirection.Output;
    //  Here there will be a Stored Procedure Call
    VendorID = Convert.ToInt32(param[0].Value);
    
