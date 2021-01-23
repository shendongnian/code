	public interface IMemberType {		
		public string Name { get; set; } // i.e. "Professional"
		public string Code { get; set; } // i.e. "MEM3"
	}
	public void ClientCode() {
		// Instantiate a concrete service (calling a factory would be even better).
		IMembershipService service = new MembershipService();
		// Get the list of MemberTypes exposed by the concrete MembershipService.
		Collecton<IMemberTypes> types = service.GetMemberTypes();
		// Subscribe to service defined in IMembershipService with "Professional" level, if possible.
		foreach (IMemeberType type in types) {
			if ((type.Name == "Professional"))
				service.SubscribeToAwesomeService(type.Code);
		}
	}
