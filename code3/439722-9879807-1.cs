    using (Connection con = /* some initialization logic */)
    {
        try
        {
            using (OracleCommand oc = new OracleCommand(query, con))
            {
                oc.CommandType = CommandType.Text;
                return oc.ExecuteScalar().ToString();
            } // oc is automatically disposed here
        }
        catch (OracleException ex)
        {
            MessageBox.Show(ex.Message);
            return string.Empty;
        }
    } // con is automatically disposed here
