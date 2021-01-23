    /// <summary>
    /// Open the Connection when creating the Object
    /// </summary>
    class DataAccess
    {
        public SqlConnection sqlConn ;
        public int gConnTimeOut = 0 ;
        public DataAccess()
        {
            string strConn = "";            
            Classes.GlobVaribles objConStr = Classes.GlobVaribles.GetInstance();
            strConn = objConStr.gConString;
            gConnTimeOut = objConStr.gQueryTimeOut;
            if (strConn == "")
            {
                XmlAccess XmlFile = new XmlAccess();
                strConn = XmlFile.Xml_Read("gConStr");
                gConnTimeOut = int.Parse(XmlFile.Xml_Read("gQueryTimeOut"));
                objConStr.gConString = strConn;
                objConStr.gQueryTimeOut = gConnTimeOut;
            }
            sqlConn =  new SqlConnection(strConn);            
            sqlConn.Open();
        }
        
        /// </summary>
        /// Can use to select one value from SELECT statment
        /// </summary>
        public string SQLER(string strSQL)
        {
            if (sqlConn.State.ToString() == "Closed") { sqlConn.Open(); }
            strSQL = SQLFormat(strSQL);
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
           
            string strResult = sqlCmd.ExecuteScalar().ToString();
            sqlCmd.Dispose();
            return strResult;
        }
        
        /// </summary>
        /// Return Data Set        
        /// </summary>
        public DataSet SQLDT(string strSQL)
        {
            //conn.Close();
            //if (conn.State.ToString() == "Closed") { conn.Open(); }
            if (sqlConn.State.ToString() == "Closed") { sqlConn.Open(); }
            SqlCommand comm = new SqlCommand();
            comm.CommandTimeout = gConnTimeOut;
            SqlDataAdapter adapt = new SqlDataAdapter();
            comm.CommandText = strSQL;
            comm.Connection = sqlConn;
            adapt.SelectCommand = comm;
            DataSet dtset = new DataSet();
            adapt.Fill(dtset);
            return dtset;
        }
       /// <summary>
        /// Can use for Execute SQL commands (Insert/Delete/Update)
        /// </summary>
        public int SQLCX(string strSQL)
        {
            try
            {
                if (sqlConn.State.ToString() == "Closed") { sqlConn.Open(); }
                strSQL = SQLFormat(strSQL);
                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
                sqlCmd.CommandTimeout = gConnTimeOut;
                int intResult = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                return intResult;
            }
            catch (Exception objError)
            {
                MessageBox.Show("System Error - " + objError.Message.ToString(),"Application Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
                return -1;
            }
            
        }
        /// <summary>
        /// Returns a SQL DataReader
        /// </summary>       
        public SqlDataReader DataReader(string strSQL)
        {
            if (sqlConn.State.ToString() == "Closed") { sqlConn.Open(); }
            strSQL = SQLFormat(strSQL);
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
            SqlDataReader dataRed = null;
            
            dataRed = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            sqlCmd.Dispose();
            return dataRed;
        }
        /// <summary>
        /// Retrun the No of Records
        /// </summary>
        public int GetNumOfRec(string strSQL)
        {
            /// Use for get No of Records in SELECT command
            try
            {
                int intResult = -1;
                if (sqlConn.State.ToString() == "Closed") { sqlConn.Open(); }
                strSQL = SQLFormat(strSQL);
                SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
                intResult = (int)sqlCmd.ExecuteScalar();
                sqlCmd.Dispose();
                return intResult;
            }
            catch (Exception objError)
            {
                MessageBox.Show("System Error - " + objError.Message.ToString(), "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        /// </summary>
        /// Fill Listview 
        /// </summary>
        public void ListViewFill(string strSQL, System.Windows.Forms.ListView lstView)
        {
            if (sqlConn.State.ToString() != "Open") { sqlConn.Open(); }
            SqlDataAdapter adapter = new SqlDataAdapter(strSQL, sqlConn);            
            DataSet ds = new DataSet("glorders");
            adapter.SelectCommand.CommandTimeout = gConnTimeOut;
            adapter.Fill(ds, "glorders");
            DataTable dt = ds.Tables[0];
            int colCount = dt.Columns.Count;
           lstView.Items.Clear();
           Color shaded = Color.FromArgb(240, 240, 240);
           int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                string[] subitems = new string[colCount];
                object[] o = row.ItemArray;
                
                
                for (int i = 0; i < colCount; i++)
                {
                    subitems[i] = o[i].ToString();                      
                }
                ListViewItem item = new ListViewItem(subitems);
                lstView.Items.Add(item);
                if (j++ % 2 == 1)
                {
                    item.BackColor = shaded;
                    item.UseItemStyleForSubItems = true;
                }
            }
            dt.Dispose();
            ds.Dispose();
            adapter.Dispose();
        }
        /// </summary>
        /// Fill ComboBox
        /// </summary>
        public void ComboFill(string strSQL, System.Windows.Forms.ComboBox dbCombo)
        {
            SqlDataReader dbReader = null;
            dbReader = DataReader(strSQL);
            dbCombo.Items.Clear();
            while (dbReader.Read()) { dbCombo.Items.Add(dbReader[0].ToString().Trim()); }
            dbReader.Dispose();
        }
        
        private string SQLFormat(string strSQL)
        {
            strSQL = strSQL.Replace("\r", " ");
            strSQL = strSQL.Replace("\n", " ");
            strSQL = strSQL.Replace("\t", " ");
            strSQL = strSQL.Replace("  ", " ");
            return strSQL;
        }
    }
