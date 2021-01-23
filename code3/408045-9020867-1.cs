    public class ThemeSwitcher
    {
        private const string ThemeSessionKey = "theme";
        
        public static string GetCurrentTheme()
        {
            var theme = HttpContext.Current.Session[ThemeSessionKey]
                as string;
            return theme ?? "Default";
        }
        public static void SaveCurrentTheme(string theme)
        {
            HttpContext.Current.Session[ThemeSessionKey]
                = theme;
        }
        public static string[] ListThemes()
        {
            return (from d in Directory.GetDirectories(HttpContext.Current.Server.MapPath("~/app_themes"))
                    select Path.GetFileName(d)).ToArray();
        }
    }
