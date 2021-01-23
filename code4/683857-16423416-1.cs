    var agent = new Agent
    {
        Id = ObjectId.GenerateNewId(),
        Name = new AgentName { First = "vbv", Last = "vbvbv" },
        LoginSessionId = "",
        GroupCode = "",
        Created = "",
        LastLogin = "",
        IsActive = "",
        Stamps = new Stamps
        {
            Inserted = "",
            Updated = "",
            CreateUser = "",
            UpdateUser = "",
            InsertIPAddress = "",
            UpdateIPAddress = ""
        }
    };
    collection.Insert(agent);
