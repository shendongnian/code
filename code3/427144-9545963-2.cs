    protected int GetTotal()
    {
        int total = 0;
        using (var Connection = new SqlCeConnection("<testConnectionString>"))
        using (var Command = new SqlCeCommand("<SQL statement>"))
        using (var Reader = Command.ExecuteReader())
        {
           while (Reader.Read())
           {
               total += (int)Reader["Total Number of Participants"];
           }
        }
        return total;
     }
