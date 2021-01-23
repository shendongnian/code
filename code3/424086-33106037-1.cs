	public static void assertSubscribed<EventHandlerType>(object handler, object subscriber, string eventName = null) {
		var inapropriate = false;
		try {
			if (!typeof (EventHandlerType).IsSubclassOf(typeof (Delegate)) ||
				typeof (EventHandlerType).GetMethod("Invoke").ReturnType != typeof (void))
				inapropriate = true;
		} catch (AmbiguousMatchException) {
			inapropriate = true;
		} finally {
			if (inapropriate) throw new Exception("Inapropriate Delegate: " + typeof (EventHandlerType).Name);
		}
		var handlerField = subscriber.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
			.First(h => h.FieldType.IsInstanceOfType(handler));
		var handlerInstance = handlerField.GetValue(subscriber);
		var eventField = handlerInstance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
			.First(f => (f.FieldType.IsAssignableFrom(typeof (EventHandlerType)) &&
						 (eventName == null || eventName.Equals(f.Name))));
		var eventInstance = (Delegate) eventField.GetValue(handlerInstance);
		var subscribedMethod = eventInstance.GetInvocationList()
			.FirstOrDefault(
				d => d.Method.DeclaringType != null && d.Method.DeclaringType.IsInstanceOfType(subscriber));
		Assert.That(subscribedMethod, Is.Not.Null);
	}
