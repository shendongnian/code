    // Call in program
    m_Info = m_InfoDAO.GetInfo();
    //Database Call
    public DataSet GetInfo()
        {
            try
            {
                if (this.cnn == null)
                    this.ConnectAndEnable(ref cnn);
                string sql = @" select '0' as select_id, folder_name, folder_name as hidden_folder, (to_char(mod_date,'MM/DD/YYYY hh12:mi AM') || ' ' || mod_user) as mod_date
                                from   index_info , index_patient
                                where  deleted_date is null
                                order by folder_name asc";
                OracleCommand cmd = new OracleCommand(sql, cnn);
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception in InfoDAO.GetInfo:  " + ex.Message);
                throw ex;
            }
        }
    //Initialize Grid
    gridInfo.DataSource = m_Info;
    gridInfo.ActiveRow = null;
    
