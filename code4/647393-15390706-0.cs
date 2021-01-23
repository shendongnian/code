    private XAttribute GetAlias(DataRow row)
    {
        if(row.Field<string>("Alias") != null)
        {
            return new XAttribute("Alias", row.Field<string>("Alias"));
        }
        return null;
    }
