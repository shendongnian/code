    public void AddPersonToCommunity(string person, string communityName)
    {
        var result = communities.Where(n => String.Equals(n.CommunityName, communityName)).FirstOrDefault();
        if (result != null)
        {
            result.Add(new Person() { Name = person });
        }
    } 
