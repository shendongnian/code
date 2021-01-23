	public static void assertNotSubscribed<EventHandlerType>(object handler, object subscriber, string eventName = null) {
		var inapropriate = false;
		try {
			if (!typeof (EventHandlerType).IsSubclassOf(typeof (Delegate)) ||
				typeof (EventHandlerType).GetMethod("Invoke").ReturnType != typeof (void))
				inapropriate = true;
		} catch (AmbiguousMatchException) {
			inapropriate = true;
		}
		if (inapropriate) return;
		var handlerField = subscriber == null ? null : subscriber.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
			.First(h => h.FieldType.IsInstanceOfType(handler));
		var handlerInstance = handlerField == null ? null : handlerField.GetValue(subscriber);
		var eventField = handlerInstance == null ? null : handlerInstance.GetType()
			.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
			.First(f => (f.FieldType.IsAssignableFrom(typeof (EventHandlerType)) &&
						 (eventName == null || eventName.Equals(f.Name))));
		var eventInstance = eventField==null?null:(Delegate) eventField.GetValue(handlerInstance);
		var subscribedMethod = eventInstance == null
			? null
			: eventInstance.GetInvocationList().FirstOrDefault(
					d => d.Method.DeclaringType != null && d.Method.DeclaringType.IsInstanceOfType(subscriber));
		Assert.That(subscribedMethod, Is.Null);
	}
