    namespace TheGame 
    {
        // declare enum with all available themes
        public enum EnumGameTheme { theme1, theme2 };
        // factory class
        public class ThemeFactory 
        {
            // factory method.  should create a theme object with the type of the enum value themeToCreate
            public static GameTheme GetTheme(EnumGameTheme themeToCreate) 
            {
                throw new NotImplementedException();
                // TODO return theme
            }
        }
 
        // TODO game theme class
        public class GameTheme { }
    }
