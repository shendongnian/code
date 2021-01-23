	using System;
	using System.Collections.Concurrent;
	using System.Threading.Tasks;
	namespace ConcurrentDictionaryCancelTest {
		class Program {
			static void Main( string[] args ) {
				var example = new ConcurrentDictionary<string, bool>();
				for( var i = 0; i < 3; i++ ) {
					example.AddOrUpdate( i.ToString(), false, ( key, oldValue ) => false );
				}
				Parallel.For( 0, 8, x => {
					example.AddOrUpdate(
						( x % 3 ).ToString(),
						( key ) => {
							Console.WriteLine( "addValueFactory called for " + key );
							return true;
						},
						( key, oldValue ) => {
							Console.WriteLine( "updateValueFactory called for " + key );
							if( !oldValue ) {
								var guid = Guid.NewGuid();
								Console.WriteLine( 
									key + " is calling UpdateLogic: " + guid.ToString() 
								);
								UpdateLogic( key, guid );
							}
							return true;
						}
					);
				} );
			}
			public static void UpdateLogic( string key, Guid guid ) {
				Console.WriteLine( 
					"UpdateLogic has been called for " + key + ": " + guid.ToString()
				);
			}
		}
	}
