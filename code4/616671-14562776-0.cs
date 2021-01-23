    private void getData()
        {
            SqlCeConnection conn = new SqlCeConnection("data source='c:\\northwind.sdf';  mode=Exclusive;");
            SqlCeDataAdapter da = new SqlCeDataAdapter("Select [Statistics] from Products",  conn);
            DataTable dtSource = new DataTable();
            da.Fill(dtSource);
            DataRow[] dr = new DataRow[dtSource.Rows.Count];
            dtSource.Rows.CopyTo(dr, 0);
            int[] dblstat= Array.ConvertAll(dr, new Converter<DataRow , int>       (DataRowToint));
        }
        public static int32 DataRowToint(DataRow dr)
        {
            return Convert.ToInt32(dr["Statistics"].ToString());
        }
