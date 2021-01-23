        private class VersionSpec
        {
            public string Address { get; private set; }
            public string CellValue { get; private set; }
            public string Version { get; private set; }
            public VersionSpec (string address, string cellValue, string version)
	        {
                Address = address;
                CellValue = cellValue;
                Version = version;
	        }
        }
        public string getVersion(Excel._Worksheet sht)
        {
            VersionSpec[] versionSpecs = new []
            {
                new VersionSpec("a4", "Changes for Version 24", "24"),
                new VersionSpec("a1", "Changes for Version 23 (Official)", "23"),
                new VersionSpec("a2", "Changes for Version 22", "22"),
                // other versions...
            }
            foreach(VersionSpec versionSpec in versionSpecs)
            {
                if(checkContents(sht, versionSpec.Address, versionSpec.CellValue))
                {
                    return versionSpec.Version;
                }
            } 
        }
