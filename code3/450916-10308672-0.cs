	namespace IsolatedStorageExample
	{
		public class ISOAccess
		{
			// This example method will read a file inside your Isolated Storage.
			public static String ReadFile(string filename)
			{
				string fileContents = "";
				// Ideally, you should enclose this entire next section in a try/catch block since
				// if there is anything wrong with below, it will crash your app.
				// 
				// This line returns the "handle" to your Isolated Storage. The phone considers the
				// entire isolated storage folder as a single "file", which is why it can be a 
				// little bit of a confusing name.
				using(IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAppliaction())
				{	
					// If the file does not exist, return an empty string
					if(file.Exists(filename))
					{
						// Obtain a stream to the file
				    	using(IsolatedStorageFileStream stream = File.OpenFile(filename, FileMode.Open)
						{
							// Open a stream reader to actually read the file.
							using(StreamReader reader = new StreamReader(stream))
							{
								fileContents = reader.ReadToEnd();
							}
						}
					}	
				}
				return fileContents;
			}
		}
	}
