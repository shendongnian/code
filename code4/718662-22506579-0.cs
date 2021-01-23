    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum e)
        {
            var rm = new ResourceManager(typeof (EnumResources));
            var resourceDisplayName = rm.GetString(e.GetType().Name + "_" + e);
            return string.IsNullOrWhiteSpace(resourceDisplayName) ? string.Format("[[{0}]]", e) : resourceDisplayName;
        }
    }
