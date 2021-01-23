    public static class Lookups
    {
        private static Dictionary<string, Vers> Versions;
        static Lookups()
        {
            Versions = new Dictionary<string, Vers>
            {
                {"0000", new Vers {VersionNumber = "0000", VersionLiteral = "Location 1"}},
                {"0001", new Vers {VersionNumber = "0001", VersionLiteral = "Location 2"}},
                {"0002", new Vers {VersionNumber = "0002", VersionLiteral = "Location 3"}},
                {"0003", new Vers {VersionNumber = "0003", VersionLiteral = "Location 4"}},
                {"0004", new Vers {VersionNumber = "0004", VersionLiteral = "Location 5"}},
                {"0005", new Vers {VersionNumber = "0005", VersionLiteral = "Location 6"}},
                {"0006", new Vers {VersionNumber = "0006", VersionLiteral = "Location 7"}},
                {"0007", new Vers {VersionNumber = "0007", VersionLiteral = "Location 8"}}
            };
        }
        public static bool VersionExists(string versionNumber)
        {
            return Versions.ContainsKey(versionNumber);
        }
        public static string GetVersion(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) throw new FormatException("Empty version number!");
            return Versions[s.Trim()].VersionLiteral;
        }
    }
