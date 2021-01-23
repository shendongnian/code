    public static class reuse
    {
        static public readonly log4net.ILog log = log4net.LogManager.GetLogger("GeneralLog");
        public static void FillDropDownList(string query, string[] parms,  DropDownList dropDown)
        {
            dropDown.Items.Clear();
            dropDown.DataSource = GetData(query, parms);
            dropDown.DataBind();
        }
        private static IEnumerable<string> GetData(string query, string[] parms)
        {
            using (SqlConnection con = new SqlConnection(GetConnString()))
            {
                try
                {
                    List<string> result = new List<string>();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddRange(parms);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.VisibleFieldCount > 0)
                    {
                        while (dr.Read())
                            result.Add(dr[0].ToString());
                    }
                    dr.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    log.Error("Exception in GetData()", ex);
                    throw;
                }
            }
        }
        private static string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString.ToString(CultureInfo.InvariantCulture);
        }
    }
