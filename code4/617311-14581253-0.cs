	static T getValue<T>( string _propName )
	{
		return getValue( _propName, default( T ) );
	}
	static T getValue<T>( string _propName, T _defaultValue )
	{
		var iss = IsolatedStorageSettings.ApplicationSettings;
		T res;
		if( iss.TryGetValue( _propName, out res ) )
			return res;
		return _defaultValue;
	}
	static void setValue( string _propName, object val )
	{
		IsolatedStorageSettings.ApplicationSettings[ _propName ] = val;
		IsolatedStorageSettings.ApplicationSettings.Save();
	}
