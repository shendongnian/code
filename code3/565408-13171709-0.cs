    System.DateTime myDate = default(System.DateTime);
    myDate = DateTimePickerPrint.Value;
    using (SqlConnection con = new SqlConnection(your-connection-string-here))
    using (SqlCommand cmd = new SqlCommand("dbo.Save_Quotation_Bookshop", con))
    {
        // tell ADO.NET it's a stored procedure (not inline SQL statements)
        cmd.CommandType = CommandType.StoredProcedure;
        // define parameters
        cmd.Parameters.Add("@QuotationNo", SqlDbType.VarChar, 50).Value = txt_QutationNo.Text;
        cmd.Parameters.Add("@CustomerCode", SqlDbtype.VarChar, 25).Value = txt_CusCode.Text;
        cmd.Parameters.Add("@SaleDate", SqlDbType.DataTime).Value = myDate;
        // open connection, execute stored procedure, close connection again
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
