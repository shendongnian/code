    Dictionary<int, string> list = new Dictionary<int, string>();
    var memberGroup = MemberGroup.GetByName("Member Group Name");
    if (memberGroup != null)
    {
            foreach (Member member in memberGroup.GetMembers())
            {
                    list.Add(member.Id, member.Name);
            }
    }
