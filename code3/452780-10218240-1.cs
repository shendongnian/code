	public abstract class DomainSpecification
	{
		protected IList<IDomainEvent> EventsRaised = new List<IDomainEvent>();
		Establish context = () => 
		{
			// subscribe to events; when raised, add to EventsRaised list
		}
	}
