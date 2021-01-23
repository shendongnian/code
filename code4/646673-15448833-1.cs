	private Action<string> _Dispatcher;
	public Action<string> Dispatcher {
		get {
			if (_Dispatcher == null) {
				return Changed;
			}
			return _Dispatcher;
		}
		set {
			_Dispatcher = value;
		}
	}
