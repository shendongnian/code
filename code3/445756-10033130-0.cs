	public Dictionary<Reason, Action<CustomClassObj, string>> ReasonHandlers = new Dictionary<Reason, Action<CustomClassObj, string>>{
		{ Reason.ReasonA, HandleReasonA },
		{ Reason.ReasonB, HandleReasonB },
		{ Reason.ReasonC, HandleReasonC }
	
	
	public Action<CustomClassObj, string> ReasonHandlerLookup (Reason reason) {
		return ReasonHandlers[reason] ?? HandleReasonGeneral;
	}
