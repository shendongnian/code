  	//
	// EnumExtensions.cs  
	//
	using System;
	using System.Collections.Generic;
	namespace EnumExtensionsLibrary
	{
		/// <summary>
		/// The functions in this class use the localized strings in the resources
		/// to translate the enum value when output to the UI and reverse--
		/// translate when receiving input from the UI to store as the actual
		/// enum value.
		/// </summary>
		/// 
		/// <Note>
		/// Some of the exported functions assume that the ParserEnumLocalizationHolder
		/// and ToStringEnumLocalizationHolder dictionaries (maps) may contain the enum 
		/// types since they callthe Initialize methods with the input type before executing.
		/// </Note>
		public static class EnumExtensions
		{
			#region Exported methods
			/// <summary>
			/// Save resource from calling project so that we can look up enums as needed.
			/// </summary>
			/// <param name="resourceManager">Where we fish the translated strings from</param>
			/// <remarks>
			/// We do not have access to all of the resources from the other projects directly,
			/// so they must be loaded from the code from within the project.
			/// </remarks>
			public static void RegisterResource(System.Resources.ResourceManager resourceManager)
			{
				if (!MapOfResourceManagers.Contains(resourceManager))
					MapOfResourceManagers.Add(resourceManager);
			}
			/// <summary>
			/// Parses the localized string value of the enum by mapping it 
			/// to the saved enum value
			/// </summary>
			/// <remarks>
			/// In some cases, string for enums in the applications may not be translated to the
			/// localized version (usually when the program presets parameters).  If the enumMap
			/// doesn't contain the value string, we call to Enum.Parse() to handle the conversion
			/// or throw an exception.
			/// </remarks>
			/// <typeparam name="T"></typeparam>
			/// <param name="value"></param>
			/// <exception cref="ArgumentNullException"> enumType or value is null.</exception>
			/// <exception cref="ArgumentException"> enumType is not an Enum. value is either an 
			/// empty string or only contains white space, value is a name, but not one of the 
			/// named constants defined for the enumeration.</exception>
			/// <exception cref="ArgumentNullException">enumType or value is null.</exception>
			/// <returns>
			/// The enum value that matched the input string if found.  If not found, we call 
			/// Enum.Parse to handle the value.
			/// </returns>
			public static T ParseEnum<T>(this string value) where T : struct
			{
				ParserInitialize(typeof(T));
				var enumMap = ParserEnumLocalizationHolder[typeof(T)];
				if (enumMap.ContainsKey(value))
					return (T) enumMap[value];
				return (T)Enum.Parse(typeof(T), value); 
			}
			/// <summary>
			/// Parses the localized string value of the enum by mapping it 
			/// to the saved enum value.  
			/// </summary>
			/// <remarks>
			/// In some cases, string for enums in the applications may not be translated to the
			/// localized version (usually when the program presets parameters).  If the enumMap
			/// doesn't contain the value string, we call to Enum.TryParse() to handle the 
			/// conversion. and return.
			/// </remarks>
			/// <typeparam name="T"></typeparam>
			/// <param name="value"></param>
			/// <param name="result"></param>
			/// <returns>
			/// Returns true if the enum mapping contains the localized string value and the data 
			/// in the returned result parameter will be a valid value of that enum type. if the
			/// string value is not mapped, then calls Enum.TryParse to handle the conversion and 
			/// return result.
			/// </returns>
			public static bool TryParseEnum<T>(this string value, out T result) where T : struct
			{
				ParserInitialize(typeof(T));
				var enumMap = ParserEnumLocalizationHolder[typeof(T)];
				if (!enumMap.ContainsKey(value))
					return Enum.TryParse(value, out result);
				result = (T)enumMap[value];
				return true;
			}
			/// <summary>
			/// Converts the enum value to a localized string.
			/// </summary>
			/// <typeparam name="T">must be an enum to work</typeparam>
			/// <param name="value">is an enum</param>
			/// <returns>
			/// The localized string equivalent of the input enum value
			/// </returns>
			public static string EnumToString<T>(this T value) where T : struct
			{
				ToStringInitialize(typeof(T));
				var toStringMap = ToStringEnumLocalizationHolder[typeof(T)];
				return toStringMap.ContainsKey(value) ? toStringMap[value] : value.ToString();
				//return EnumDescription(value);
			}
			/// <summary>
			/// Gathers all of the localized translations for each 
			/// value of the input enum type into an array
			/// </summary>
			/// <remarks>
			/// The return array from Type.GetEnumValues(), the array elements are sorted by 
			/// the binary values (that is, the unsigned values) of the enumeration constants.
			/// </remarks>
			/// <param name="enumType"></param>
			/// <exception cref="ArgumentException"> The current type is not an enumeration.</exception>
			/// <returns>
			/// A string array with the localized strings representing
			/// each of the values of the input enumType.
			/// </returns>
			public static string[] AllDescription(this Type enumType)
			{
				ToStringInitialize(enumType);
				var descriptions = new List<string>();
				var values = enumType.GetEnumValues();
				var toStringMap = ToStringEnumLocalizationHolder[enumType];
				foreach (var value in values)
				{
					descriptions.Add(toStringMap.ContainsKey(value) ? toStringMap[value] : value.ToString());
				}
				return descriptions.ToArray();
			}
			#endregion
			#region Helper methods
			/// <summary>
			/// Translates an enum value into its localized string equivalent
			/// </summary>
			/// <remarks>
			/// This assumes that the "name" for the localized string in the 
			/// resources will look like "enum-type-name""value".  For example,  
			/// if I have an enum setup as:
			/// 
			///     enum Days {Sat, Sun, Mon, Tue, Wed, Thu, Fri};
			/// 
			/// the value "Sun" in the enum must have the name: "DaysSun"
			/// in the resources. The localized (translated) string will
			/// be in the value field.  E.g.,
			///
			///  <data name="DaysSun" xml:space="preserve">
			///	<value>Sunday</value>
			///  </data>	
			/// 
			/// 2nd note: there may be multiple resources to pull from.
			/// Will look in each resource until we find a match or 
			/// return null.
			/// </remarks>
			/// <typeparam name="T"></typeparam>
			/// <param name="enumType">the enum type</param>
			/// <param name="value">the specific enum value</param>
			/// <returns>
			/// If the enum value is found in the resources, then return 
			/// that string.  If not, then return null. 
			/// </returns>
			private static string LocalEnumDescription<T>(Type enumType, T value)
			{
				foreach (var resourceManager in MapOfResourceManagers)
				{
					// The following live line uses string interpolation to perform:
					//var rk = string.Format("{0}{1}", enumType.Name, value);
					var rk = $"{enumType.Name}{value}";
					// Given the above string formatting/interpolation, neither the enum.Name 
					// nor the value will have a '.' so we do not have to remove it.
					var result = resourceManager.GetString(rk);
					if (!string.IsNullOrEmpty(result))
						return result;
				}
				return null;
			}
			/// <summary>
			/// Initializes the mapping of the enum type to its mapping of localized strings to 
			/// the enum's values.
			/// </summary>
			/// <remarks>
			/// The reason for each enum type to have a mapping from the localized string back 
			/// to its values is for ParseEnum and TryParseEnum to quickly return a value rather
			/// than doing a lengthy loop comparing each value in the resources.
			/// 
			/// Also, we only map the corresponding resource string if it exists in the resources.
			/// If not in the resources, then we call the Enum methods Parse() and TryParse() to
			/// figure the results and throw the appropriate exception as needed.
			/// </remarks>
			/// 
			/// <param name="enumType"></param>
			private static void ParserInitialize(Type enumType)
			{
				if (!ParserEnumLocalizationHolder.ContainsKey(enumType))
				{
					var values = enumType.GetEnumValues();  // See remark for AllDescription().
					var enumMap = new Dictionary<string, object>();
					foreach (var value in values)
					{
						var description = LocalEnumDescription(enumType, value);
						if (description != null)
							enumMap[description] = value;
					}
					ParserEnumLocalizationHolder[enumType] = enumMap;
				}
			}
			/// <summary>
			/// Initializes the mapping of the enum type to its mapping of the enum's values
			/// to their localized strings.
			/// </summary>
			/// <remarks>
			/// The reason for each enum type to have a mapping from the localized string to its
			/// values is for AllDescription and EnumToString to quickly return a value rather 
			/// than doing a lengthy loop runing through each of the resources.
			/// 
			/// Also, we only map the corresponding resource string if it exists in the resources.
			/// See the EnumDescription method for more information.
			/// </remarks>
			/// 
			/// <param name="enumType"></param>
			private static void ToStringInitialize(Type enumType)
			{
				if (!ToStringEnumLocalizationHolder.ContainsKey(enumType))
				{
					var values = enumType.GetEnumValues();  // See remark for AllDescription().
					var enumMap = new Dictionary<object, string>();
					foreach (var value in values)
					{
						var description = LocalEnumDescription(enumType, value);
						if (description != null)
							enumMap[value] = description;
					}
					ToStringEnumLocalizationHolder[enumType] = enumMap;
				}
			}
			#endregion
			#region Data
			private static readonly List<System.Resources.ResourceManager> MapOfResourceManagers =
				new List<System.Resources.ResourceManager>();
			private static readonly Dictionary<Type, Dictionary<string, object>> ParserEnumLocalizationHolder =
				new Dictionary<Type, Dictionary<string, object>>();
			private static readonly Dictionary<Type, Dictionary<object, string>> ToStringEnumLocalizationHolder =
				new Dictionary<Type, Dictionary<object, string>>();
			#endregion
		}
	}
