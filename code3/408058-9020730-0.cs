        public static Dictionary<String, String> ThemeColors
        {
            get
            {
                Dictionary<String, String> themeColors = new Dictionary<string, string>();
                foreach (String colorAndCode in GetSettingByName("ThemeColors").ToString().Split('|'))
                {
                    var parts = colorAndCode.Split(':');
                    themeColors.Add(parts[0], parts[1]);
                }
                return themeColors;
            }
        }
