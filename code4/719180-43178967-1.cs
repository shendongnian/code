    //Common DLL client, server
    public class transferDataTable
    {
        public class myError
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }
        public myError Error { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<string> DataTypes { get; set; }
        public List<Object> Data { get; set; }
        public int Count { get; set; }
    }
    public static class ExtensionMethod
    {
        public static DataTable GetDataTable(this transferDataTable transfer, bool ConvertToLocalTime = true)
        {
            if (transfer.Error != null || transfer.ColumnNames == null || transfer.DataTypes == null || transfer.Data == null)
                return null;
            int columnsCount = transfer.ColumnNames.Count;
            DataTable dt = new DataTable();
            for (int i = 0; i < columnsCount; i++ )
            {
                Type colType = Type.GetType(transfer.DataTypes[i]);
                dt.Columns.Add(new DataColumn(transfer.ColumnNames[i], colType));
            }
            int index = 0;
            DataRow row = dt.NewRow();
            foreach (object o in transfer.Data)
            {
                if (ConvertToLocalTime && o != null && o.GetType() == typeof(DateTime))
                {
                    DateTime dat = Convert.ToDateTime(o);
                    row[index] = dat.ToLocalTime();
                }
                else
                    row[index] = o == null ? DBNull.Value : o;
                index++;
                if (columnsCount == index)
                {
                    index = 0;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                }
            }
            return dt;
        }
        public static transferDataTable LoadData(this transferDataTable transfer, DataTable dt)
        {
            if (dt != null)
            {
                transfer.DataTypes = new List<string>();
                transfer.ColumnNames = new List<string>();                
                foreach (DataColumn c in dt.Columns)
                {
                    transfer.ColumnNames.Add(c.ColumnName);
                    transfer.DataTypes.Add(c.DataType.ToString());
                }
                transfer.Data = new List<object>();
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        transfer.Data.Add(dr[col] == DBNull.Value ? null : dr[col]);
                    }
                }
                transfer.Count = dt.Rows.Count;
            }            
            return transfer;
        }        
    }
    //Server
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "json/data")]
        transferDataTable _Data();
        public transferDataTable _Data()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["myConnString"]))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter myAdapter = new SqlDataAdapter("SELECT * FROM tbGalleries", con);
                    myAdapter.Fill(ds, "table");
                    DataTable dt = ds.Tables["table"];
                    return new transferDataTable().LoadData(dt);
                }
            }
            catch(Exception ex)
            {
                return new transferDataTable() { Error = new transferDataTable.myError() { Message = ex.Message, Code = ex.HResult } };
            }
        }
    //Client
            Response = Vossa.getAPI(serviceUrl + "json/data");
            transferDataTable transfer = new JavaScriptSerializer().Deserialize<transferDataTable>(Response);
            if (transfer.Error == null)
            {
                DataTable dt = transfer.GetDataTable();
                dbGrid.ItemsSource = dt.DefaultView;
            }
            else
                MessageBox.Show(transfer.Error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
