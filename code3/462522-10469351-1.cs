    List<MultiServiceRequestMember> _memberList = new List<MultiServiceRequestMember>();
    var type = Type.GetType(svc.NotificationClassName);
    MultiServiceRequestMember newMember = null;
    if (type == typeof(MultiServiceRequestMemberA))
    {
    	newMember = new MultiServiceRequestMemberA();
    	//set specific properties
    }
    else if (type == typeof(MultiServiceRequestMemberB)) //etc.
    {
    	//...
    }
    else
    {
    	//throw or some default
    }
    
    _memberList.add(newMember);
