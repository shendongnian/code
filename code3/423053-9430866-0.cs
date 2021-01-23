    public class ClientGroupDetails
    {
        public Nullable<DateTime> Col2;
        public String Col3;
        public Int32 Col4;
    
        public ClientGroupDetails(Nullable<DateTime> m_Col2, String m_Col3, Int32 m_Col4)
        {
            Col2 = m_Col2;
            Col3 = m_Col3;
            Col4 = m_Col4;
        }
    
        public ClientGroupDetails() { }
    }
    
    [WebMethod()]
    public List<ClientGroupDetails> GetClientGroupDetails(string phrase)
    {
        var client_group_details = new List<ClientGroupDetails>();
        using (connection = new SqlConnection(ConfigurationManager.AppSettings["connString"]))
        {
            using (command = new SqlCommand(@"select col2, col3, col4 from table1 where col1 = @strSearch", connection))
            {
                command.Parameters.Add("@strSearch", SqlDbType.VarChar, 255).Value = phrase;
    
                connection.Open();
                using (reader = command.ExecuteReader())
                {
                    int Col2Index = reader.GetOrdinal("col2");
                    int Col3Index = reader.GetOrdinal("col3");
                    int Col4Index = reader.GetOrdinal("col4");
    
                    while (reader.Read())
                    {
                        client_group_details.Add(new ClientGroupDetails(
                            reader.IsDBNull(Col2Index) ? (Nullable<DateTime>)null : (Nullable<DateTime>)reader.GetDateTime(Col2Index),
                            reader.IsDBNull(Col3Index) ? (string)null : reader.GetString(Col3Index),
                            reader.GetInt32(Col4Index)));
                    }
                }
            }
        }
    
        return client_group_details;
    }
    }
