    class MultiServiceRequestMember
    {
    	public virtual void Initialize(NotificationInfo notificationInfo) //or abstract if you wish
    	{
    	}
    }
    
    class MultiServiceRequestMemberA : MultiServiceRequestMember
    {
    	public override void Initialize(NotificationInfo notificationInfo)
    	{
    		base.Initialize(notificationInfo);
    		this.A = notificationInfo.A;
    	}
    }
