		public static Type GetGenericBaseType( this Type Type ) {
			if ( Type == null ) {
				throw new ArgumentNullException( "Type" );
			}
			if ( !Type.IsGenericType ) {
				throw new ArgumentOutOfRangeException( "Type", Type.FullName + " isn't Generic" );
			}
			Type[] args = Type.GetGenericArguments();
			if ( args.Length != 1 ) {
				throw new ArgumentOutOfRangeException( "Type", Type.FullName + " isn't a Generic type with one argument -- e.g. T<U>" );
			}
			return args[0];
		}
