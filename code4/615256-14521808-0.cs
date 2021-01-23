    public string INSERT_record(DateTime? leaseExpirey)
    {
        // ...
        command.Parameters.Add("@leaseExpirey", SqlDbType.DateTime);
        command.Parameters["@leaseExpirey"].Value =
                    ((object)leaseExpirey) ?? DBNull.Value;
        // ...
    }
