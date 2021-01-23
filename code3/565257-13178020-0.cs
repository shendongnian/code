    private void PopulateNullParameters(OracleCommand cmd)
        {
            foreach (OracleParameter p in cmd.Parameters)
            {
                if (p.Value == null)
                {
                    p.Value = DBNull.Value;
                }
            }
        }
