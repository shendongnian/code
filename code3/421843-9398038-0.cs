    string s1, s2;
    if (reader.IsDbNull(Col1Index) == false)
    {
       s1 = reader.GetString(Col1Index);
    }
    if (reader.IsDbNull(Col2Index) == false)
    {
       s2 = reader.GetString(Col2Index);
    }
    client_group_details.Add(new ClientGroupDetails(s1, s2));
