	public class NamedTask<T> : Task<T> {
		public string MethodName { get; set; }
		public NamedTask(Func<T> function) : base(function) {
			MethodName = function.Method.Name;
		}
		public NamedTask(Func<T> function, string methodName) : base(function) {
			MethodName = methodName;
		}
		...
	}
