    String firstname = reader.GetString(1);
    String lastname = reader.GetString(2);
    String occupation = reader.GetString(3);
    String deployment = reader.GetString(4);
    String disasterid = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
    String location = reader.GetString(6);
    String deployedhours = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
    String resthours = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
    
    list.Add(firstname);
    list.Add(lastname);
    list.Add(occupation);
    list.Add(deployment);
    list.Add(disasterid);
    list.Add(location);
    list.Add(deployedhours);
    list.Add(resthours);
