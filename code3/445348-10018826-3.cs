	internal class DynamicSession : DynamicObject
	{
		private HttpSessionState_session;
		public DynamicSession()
		{
			_session = HttpContext.Current.Session;
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			if (_session[binder.Name] != null)
			{
				result = _session[binder.Name];
				return true;
			}
			result = null;
			return false;
		}
		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			_session[binder.Name] = value;
			return true;
		}
	}
