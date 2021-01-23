	public interface IEvent { }
	public interface IHandle<TEvent> where TEvent : IEvent {
		void Handle(TEvent e);
	}
	public static class EventBus {
		public static void RaiseEvent(TEvent e) where TEvent : IEvent {
			foreach (var handler in ObjectFactory.GetAllInstances<IHandle<TEvent>>())
				handler.Handle(e);
		}
	}
