		public Type GetClosestType(Type a, Type b) {
			var t=a;
			while(a!=null) {
				if(a.IsAssignableFrom(b))
					return a;
				a=a.BaseType;
			}
			return null;
		}
