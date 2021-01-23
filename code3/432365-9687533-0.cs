    // This is my SessionFactory (Not Relevant!)
    using (var session = NhSessionFactory.GetSession(generatedatabase: false))
    {
	using (var tran = session.BeginTransaction())
	{
		var theEvent = new EventBO();
		theEvent.Name = "EventName";
		var parentInvitee = new InviteeBO();
		parentInvitee.Name = "Parent";
		theEvent.Invitees.Add(parentInvitee);
		for (int index = 0; index <= 5; index++)
		{
			var childInvitee = new InviteeBO();
			childInvitee.Name = string.Format("Child {0}", index);
			childInvitee.InvitedByUser = parentInvitee;  // Adding invited by user.
			parentInvitee.Invitees.Add(childInvitee);
			theEvent.Invitees.Add(childInvitee);   // Adding child invitees to Event.
		}
		session.SaveOrUpdate(theEvent);
		tran.Commit();
	}
    }
