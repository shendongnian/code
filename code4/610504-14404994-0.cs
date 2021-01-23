	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using SharpDX.DirectWrite;
	namespace EnumerateFonts
	{
		public class InstalledFont
		{
			public string Name { get; set; }
			// Code taken straight from SharpDX\Samples\DirectWrite\FontEnumeration\Program.cs
			public static List<InstalledFont> GetFonts()
			{
				var fontList = new List<InstalledFont>();
				var factory = new Factory();
				var fontCollection = factory.GetSystemFontCollection(false);
				var familyCount = fontCollection.FontFamilyCount;
				for (int i = 0; i < familyCount; i++)
				{
					var fontFamily = fontCollection.GetFontFamily(i);
					var familyNames = fontFamily.FamilyNames;
					int index;
					if (!familyNames.FindLocaleName(CultureInfo.CurrentCulture.Name, out index))
						familyNames.FindLocaleName("en-us", out index);
					string name = familyNames.GetString(index);
					fontList.Add(new InstalledFont()
									 {
										 Name = name,
									 });
				}
				return fontList;
			}
		}
	}
