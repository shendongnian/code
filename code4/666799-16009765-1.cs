    public class FileHelper : BaseFileHelper 
    	{
    		public static string ReadAllText(string filePath)
    		{
    			var entryAssemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:", ""), "MyExecutableAssemblyName.dll");
                        // This is because Assembly.GetEntryAssembly() returns null on Android... Booohhh
    			var assembly = Assembly.LoadFrom(entryAssemblyPath);
    			using (var stream = assembly.GetManifestResourceStream(filePath.GetFullPath()))
    			{
    				using (var reader = new StreamReader(stream))
    				{
    					return reader.ReadToEnd();
    				}
    			}
    		}
       }
