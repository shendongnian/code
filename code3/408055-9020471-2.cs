     public static Dictionary<String, String> ThemeColors2
            {
                get
                {
                    return GetSettingByName("ThemeColors").ToString().Split('|').Select(x => x.Split(new[] { ':' }, 2)).ToDictionary(x => x[0], x => x[1]);
                }
            }
