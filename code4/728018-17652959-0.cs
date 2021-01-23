	public static class KnownTypesHelper
	{
		/// <summary>
		/// Lists all WCF known types
		/// </summary>
		/// <param name="provider"></param>
		/// <returns>A collection of all WCF known types</returns>
		public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
		{
			System.Collections.Generic.List<System.Type> knownTypes =
				new System.Collections.Generic.List<System.Type>();
			knownTypes.Add(typeof(WrntyCommon.WrntyDBEnums));
			// Add any types to include here.
			knownTypes.Add(typeof(AAA));
			knownTypes.Add(typeof(BBB));
			knownTypes.Add(typeof(CCC));
			return knownTypes;
		}
	}
