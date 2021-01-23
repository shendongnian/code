		public List<string> MergeClientFiles( string path )
		{
			// Find all clients
			Array clients = Enum.GetValues( typeof( Clients ) );
			// Create a new array of files
			string[] files = new string[clients.Length];
			// Combine the clients with the .txt extension
			for( int i = 0; i < clients.Length; i++ )
				files[i] = clients.GetValue( i ) + ".txt";
			List<string> errors = new List<string>();
			// Merge the files into AllClientData
			using( var output = File.Create( path ) ) {
				foreach( var file in files ) {
					try {
						using( var input = File.OpenRead( file ) ) {
							input.CopyTo( output );
						}
					}
					catch( FileNotFoundException ) {
						errors.Add( file );
					}
				}
			}
			return errors;
		}
