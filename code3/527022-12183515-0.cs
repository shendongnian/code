    string newVendorID = "";
    try
    {
          Vendor_ID.Direction = System.Data.ParameterDirection.Output;
          SqlCon.Open();
          cmd.ExecuteNonQuery();
          if(Vendor_ID.Value != null)
              newVendorID = Vendor_ID.Value.ToString();
    }
