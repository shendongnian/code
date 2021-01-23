    using (Connection con = /* some initialization logic */)
    {
        using (OracleCommand oc = new OracleCommand(query, con))
        {
            oc.CommandType = CommandType.Text;
            try
            {
                return oc.ExecuteScalar().ToString();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
                return string.Empty;
            }
        } // oc is automatically disposed here
    } // con is automatically disposed here
