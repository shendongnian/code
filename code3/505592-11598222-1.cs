    using System;
    using System.Collections.Generic;
    namespace FunctionLibrary
    {
	public static class Lookups
	{
		private static Dictionary<string, Vers> Versions = new Dictionary<string, Vers>();
		static Lookups() //Static constructor
		{
			CreateVesions();
		}
		public static string GetVersion(string s)
		{
			string retValue = string.Empty;
                        s = s.Trim();
			if (s.Length > 0 && Versions.ContainsKey(s))
			{
				retValue = Versions[s].VersionLiteral;
			}
			if (string.IsNullOrEmpty(retValue))
			{
				retValue = string.Format("{0} is an Unknown Version Number", s);
			}
			return retValue;
		}
		private static void CreateVesions()
		{
			Versions["0000"] = new Vers() { VersionNumber = "0000", VersionLiteral = "Location 1" };
			Versions["0001"] = new Vers() { VersionNumber = "0001", VersionLiteral = "Location 2" };
			Versions["0002"] = new Vers() { VersionNumber = "0002", VersionLiteral = "Location 3" };
			Versions["0003"] = new Vers() { VersionNumber = "0003", VersionLiteral = "Location 4" };
			Versions["0004"] = new Vers() { VersionNumber = "0004", VersionLiteral = "Location 5" };
			Versions["0005"] = new Vers() { VersionNumber = "0005", VersionLiteral = "Location 6" };
			Versions["0006"] = new Vers() { VersionNumber = "0006", VersionLiteral = "Location 7" };
			Versions["0007"] = new Vers() { VersionNumber = "0007", VersionLiteral = "Location 8" };
		}
	}
	public class Vers
	{
		public string VersionLiteral { get; set; }
		public string VersionNumber { get; set; }
	}
