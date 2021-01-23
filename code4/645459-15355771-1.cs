        public bool IsExistRecord(string Query)
        {
            try
            {
                DataTable DT = new DataTable();
                SqlCommand CMD = new SqlCommand(Query, Connection);
                SqlDataAdapter DA = new SqlDataAdapter(CMD);
                DA.Fill(DT);
                if (DT.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
               return false;
            }
        }
