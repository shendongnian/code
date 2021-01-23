        public static string GetTeamviewerID()
        {
            var versions = new[] {"4", "5", "5.1", "6", "7", "8"}.Reverse().ToList(); //Reverse to get ClientID of newer version if possible
            foreach (var path in new[]{"SOFTWARE\\TeamViewer","SOFTWARE\\Wow6432Node\\TeamViewer"})
            {
                if (Registry.LocalMachine.OpenSubKey(path) != null)
                {
                    foreach (var version in versions)
                    {
                        var subKey = string.Format("{0}\\Version{1}", path, version);
                        if (Registry.LocalMachine.OpenSubKey(subKey) != null)
                        {
                            var clientID = Registry.LocalMachine.OpenSubKey(subKey).GetValue("ClientID");
                            if (clientID != null) //found it?
                            {
                                return Convert.ToInt32(clientID).ToString();
                            }
                        }
                    }
                }
            }
            //Not found, return an empty string
            return string.Empty;
        }
