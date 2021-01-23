    Newtonsoft.Json.JsonSerializerSettings jss = new Newtonsoft.Json.JsonSerializerSettings();
    if (includePrivateMembers)
    {
        Newtonsoft.Json.Serialization.DefaultContractResolver dcr = new Newtonsoft.Json.Serialization.DefaultContractResolver();
        dcr.DefaultMembersSearchFlags |= System.Reflection.BindingFlags.NonPublic;
        jss.ContractResolver = dcr;
    }
    return Newtonsoft.Json.JsonConvert.SerializeObject(o, jss);
