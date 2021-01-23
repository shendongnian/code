    public string GetPartyDetailsByName(string name)
    {
        return GetData("select * from [Party Details] where name=@name", p =>
        {
           p.Add("@name", SqlDbType.NVarChar, 50).Value = name;
        }, row =>
        {
           row.GetString(0);
        }).First();
    }
