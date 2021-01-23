    using (SqlConnection conn = new SqlConnection("OMG look a connection string"))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT xValue, yValue FROM chartPoints"))
        {
            try
            {
                conn.Open()
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    chartSellThru.Series["QTDRatio"].Points.DataBindXY(rdr, "xValue", rdr, "yValue");
                }
            }
            catch(Exception ex)
            {
                //handle errors
            }
        }
    }
