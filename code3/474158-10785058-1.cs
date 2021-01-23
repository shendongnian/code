	public SomeEvent : CompositePresentationEvent<SomeEvent>
	{
	    public SomeEvent(string optionalMessage)
		{
		    this.optionalMessage = optionalMessage;
		}
		
		public string OptionalMessage { get { return optionalMessage; } } 
	}
