	public class NamedTask : Task {
		public string MethodName { get; set; }
		public NamedTask(Action action) : base(action) {
			MethodName = action.Method.Name;
		}
		public NamedTask(Action action, CancellationToken cancellationToken) : base(action, cancellationToken) {}
		public NamedTask(Action action, TaskCreationOptions creationOptions) : base(action, creationOptions) {}
		public NamedTask(Action action, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, cancellationToken, creationOptions) {}
		public NamedTask(Action<object> action, object state) : base(action, state) {}
		public NamedTask(Action<object> action, object state, CancellationToken cancellationToken) : base(action, state, cancellationToken) {}
		public NamedTask(Action<object> action, object state, TaskCreationOptions creationOptions) : base(action, state, creationOptions) {}
		public NamedTask(Action<object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions) : base(action, state, cancellationToken, creationOptions) {}
	}
