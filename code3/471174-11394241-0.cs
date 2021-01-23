    public class LazyReader {
        SqlDataReader m_reader;
        SqlCommand m_command;
        SqlConnection m_connection;
        public LazyReader(SqlConnection connection, String sql)
        {
            m_command = new SqlCommand(sql, connection);
            m_connection = connection;
        }
        public IEnumerable<Object[]> read()
        {
            m_connection.Open();
            m_reader = command.ExecuteReader();
            while (m_reader.HasRows)
            {
                while (m_reader.Read())
                {
                    Object[] values = new Object[m_reader.FieldCount];
                    m_reader.GetValues(values);
                    yield return values;
                }
                m_reader.NextResult();
            }
            m_reader.Close();
        }
    }
