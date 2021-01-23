	public class NarrowingSubscriber<TBase, TDerived> : IEventSubscriber<TBase>
		where TDerived : TBase
		where TBase : IEvent
	{
		private IEventSubscriber<TDerived> inner;
		public NarrowingSubscriber(IEventSubscriber<TDerived> inner)
		{
			if (inner == null) throw new ArgumentNullException("inner");
			this.inner = inner;
		}
		public void AttachSubscriber(IEventSubscriber<TDerived> subscriber)
		{
			inner = subscriber;
		}
		public void Handle(TBase data)
		{
			inner.Handle((TDerived)data);
		}
	}
	public class Multiplexor<T> : IEventSubscriber<T> where T : IEvent
	{
		private readonly List<IEventSubscriber<T>> subscribers =
			new List<IEventSubscriber<T>>();
		public void AttachSubscriber(IEventSubscriber<T> subscriber)
		{
			subscribers.Add(subscriber);
		}
		public void RemoveSubscriber(IEventSubscriber<T> subscriber)
		{
			subscribers.Remove(subscriber);
		}
		public void Handle(T data)
		{
			subscribers.ForEach(x => x.Handle(data));
		}
	}
	public class Dispatcher<TBase> : IEventPublisher<TBase> where TBase : IEvent
	{
		private readonly Dictionary<Type, Multiplexor<TBase>> subscriptions =
			new Dictionary<Type, Multiplexor<TBase>>();
		public void Publish(TBase data)
		{
			Multiplexor<TBase> multiplexor;
			if (subscriptions.TryGetValue(data.GetType(), out multiplexor))
			{
				multiplexor.Handle(data);
			}
		}
		public void Subscribe<TEvent>(IEventSubscriber<TEvent> handler)
			where TEvent : TBase
		{
			Multiplexor<TBase> multiplexor;
			if (!subscriptions.TryGetValue(typeof(TEvent), out multiplexor))
			{
				multiplexor = new Multiplexor<TBase>();
				subscriptions.Add(typeof(TEvent), multiplexor);
			}
			multiplexor.AttachSubscriber(new NarrowingSubscriber<TBase, TEvent>(handler));
		}
	}
