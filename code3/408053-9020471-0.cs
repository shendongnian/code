     public static Dictionary<String, String> ThemeColors
        {
            get
            {
               return GetSettingByName("ThemeColors").ToString().Split('|').ToDictionary(colorAndCode => colorAndCode.Split(':').First(), colorAndCode => colorAndCode.Split(':').Last());
            }
        }
