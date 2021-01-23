    try
    {
        // omit the OracleConnection using if you receive it from elsewhere
        using (OracleConnection con = new OracleConnection(...))
        using (OracleCommand oc = new OracleCommand(query, con))
        {
            oc.CommandType = CommandType.Text;
            // nothing was going to be thrown with just 'return s'
            return oc.ExecuteScalar().ToString();
        }
    }
    catch (OracleException ex)
    {
        MessageBox.Show(ex.Message);
    }
    return string.Empty;
