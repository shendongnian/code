	static class ZipCodes
	{
		private static Object zipLocker = new Object();
		#region Methods
		public static string GetValue(string key)
		{
			lock (zipLocker)
			{
				string result;
				if (zipCodeDictionary.TryGetValue(key, out result))
				{
					return result;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion
		#region ZipCode Dictionary Definition
		static Dictionary<string, string> zipCodeDictionary = null;
		public static void PopulateZipCodeDictionary()
		{
			Dictionary<string, string> workingDictionary = new Dictionary<string, string>();
			
			workingDictionary.Add( "00501", "Holtsville, NY" );
			workingDictionary.Add( "00544", "Holtsville, NY" );
			workingDictionary.Add( "00601", "Adjuntas, PR" );
			workingDictionary.Add( "00602", "Aguada, PR" );
			workingDictionary.Add( "00603", "Aguadilla, PR" );
			workingDictionary.Add( "00604", "Aguadilla, PR" );
			//Continues on adding ~40k entries...
				
			lock (zipLocker)
			{
				zipCodeDictionary = workingDictionary;
			}
		}
	}
