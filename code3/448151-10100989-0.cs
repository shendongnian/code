     private void getData()
            {
                SqlCeConnection conn = new SqlCeConnection("data source='c:\\northwind.sdf'; mode=Exclusive;");
                SqlCeDataAdapter da = new SqlCeDataAdapter("Select [Unit Price] from Products", conn);
                DataTable dtSource = new DataTable();
                da.Fill(dtSource);
                DataRow[] dr = new DataRow[dtSource.Rows.Count];
                dtSource.Rows.CopyTo(dr, 0);
                double[] dblPrice= Array.ConvertAll(dr, new Converter<DataRow , Double>(DataRowToDouble));
    
            }
    
            public static double DataRowToDouble(DataRow dr)
            {
                return Convert.ToDouble(dr["Unit Price"].ToString());
            }
