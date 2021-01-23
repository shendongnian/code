    public static class EnumListHelper
    {
        private static void EnsureIsEnum<TEnum>()
        {
            if (!typeof(TEnum).IsEnum)
                throw new InvalidOperationException(string.Format("The {0} type is not an enum.", typeof(TEnum)));
        }
    
        public static List<TEnum> FromDatabase<TEnum>(string aDisplayModeString)
            where TEnum : struct
        {
            EnsureIsEnum<TEnum>();
            //Default behaviour
            List<TEnum> result = new List<TEnum>();
    
            //Split the string list into a list of strings
            List<string> listOfDisplayModes = new List<string>(aDisplayModeString.Split(','));
    
            //Iterate the enum looking for matches in the list
            foreach (Enum displayModeEnum in Enum.GetValues(typeof(TEnum)))
            {
                if (listOfDisplayModes.FindIndex(item => item == (string)displayModeEnum.GetCustomUserData()) >= 0)
                {
                    result.Add((TEnum)(object)displayModeEnum);
                }
            }
    
            return result;
        }
    
        public static string ToDatabase<TEnum>(List<TEnum> aDisplayModeList)
            where TEnum : struct
        {
            EnsureIsEnum<TEnum>();
            string result = string.Empty;
    
            foreach (var listItem in aDisplayModeList.OfType<Enum>())
            {
                if (result != string.Empty)
                    result += ",";
                result += listItem.GetCustomUserData();
            }
    
            return result;
        }
    }
    var fromDatabase = EnumListHelper.FromDatabase<TestEnum>("test");
    EnumListHelper.ToDatabase(fromDatabase);
