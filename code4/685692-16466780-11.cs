    public string GetPartyDetailsByNameAddress(string name, string address)
    {
        return GetData("select * from [Party Details] where name=@name and address=@address", p =>
        {
           p.Add("@name", SqlDbType.NVarChar, 50).Value = name;
           p.Add("@address", SqlDbType.NVarChar,200).Value = address;
        }, row =>
        {
           row.GetString(0);
        }).First();
    }
