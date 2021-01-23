       DataTable dtProducts = ConvertListToDataTable(_product);
       SqlCommand cmd = new SqlCommand("sp_InsertProducts", sqlConnection);
       SqlParameter p = cmd.Parameters.AddWithValue("@tvpNewDistricts", dtProducts );
       p.SqlDbType = SqlDbType.Structured;
       p.TypeName = "dbo.ProductType";
       cmd.ExecuteNonQuery();
