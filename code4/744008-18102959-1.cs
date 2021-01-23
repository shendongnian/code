        private bool GetDataSetForQuery(string sqlQuery)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, this.Connection);
                da.Fill(ds);
                this.Records = ds;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { }
        }
