    namespace TheGame 
    {
        public enum EnumGameTheme { theme1, theme2 };
        public class ThemeFactory 
        {
            public static GameTheme GetTheme(EnumGameTheme themeToCreate) 
            {
                throw new NotImplementedException();
                // TODO return theme
            }
        }
 
        public class GameTheme { }
    }
