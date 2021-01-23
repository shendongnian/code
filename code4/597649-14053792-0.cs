    bool isGroupValid = String.IsNullOrEmpty(groupId);
    someList = CTX.Values.Include(c => c.Customer)
           .Where(c => isGroupValid
                   || c.GroupId== groupId)
           .ToList();
