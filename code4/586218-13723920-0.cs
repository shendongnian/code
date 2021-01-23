        private static CultureInfo GetCulture(string name)
        {
            if (!CultureExists(name)) return null;
            return CultureInfo.GetCultureInfo(name);
        }
        private static bool CultureExists(string name)
        {
            CultureInfo[] availableCultures =
                CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in availableCultures)
            {
                if (culture.Name.Equals(name))
                    return true;
            }
            return false;
        }
