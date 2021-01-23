	public Dictionary<Reason, Action<CustomClassObj, string>> ReasonHandlers = new Dictionary<Reason, Action<CustomClassObj, string>>{
		{ Reason.ReasonA, HandleReasonA },
		{ Reason.ReasonB, HandleReasonB },
		{ Reason.ReasonC, HandleReasonC }
	
	
	public Action<CustomClassObj, string> ReasonHandlerLookup (Reason reason) {
        Action<CustomClassObj, string> result = null;
        ReasonHandlers.TryGetValue(reason, out result);
		return result ?? HandleReasonGeneral;
	}
