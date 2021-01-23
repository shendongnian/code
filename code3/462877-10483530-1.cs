	public List<T> LoadPluginsFromPath<T>( string Path ) {			
		List<T> results = new List<T>();
		DirectoryInfo Directory = new DirectoryInfo( Path );
		if ( !Directory.Exists ) {
			return results; // Nothing to do here
		}
		FileInfo[] files = Directory.GetFiles( "*.dll" );
		if ( files != null && files.Length > 0 ) {
			foreach ( FileInfo fi in files ) {
				List<T> step = LoadPluginFromAssembly( fi.FullName );
				if ( step != null && step.Count > 0 ) {
					results.AddRange( step );
				}
			}
		}
		return results;
	}
	private List<T> LoadPluginFromAssembly<T>( string Filename ) {
		List<T> results = new List<T>();
		Type pluginType = typeof( T );
		Assembly assembly = Assembly.LoadFrom( Filename );
		if ( assembly == null ) {
			return results;
		}
		Type[] types = assembly.GetExportedTypes();
		foreach ( Type t in types ) {
			if ( !t.IsClass || t.IsNotPublic ) {
				continue;
			}
			if ( pluginType.IsAssignableFrom( t ) ) {
				T plugin = Activator.CreateInstance( t ) as T;
				if ( plugin != null ) {
					results.Add( plugin );
				}
			}
		}
		return results;
	}
