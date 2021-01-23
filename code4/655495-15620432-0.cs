    private static bool AreAllStringsValidNumberRepresenationsForCulture(CultureInfo ci, List<string> lst)
    {
        foreach (string s in lst)
        {
            double number;
            if (!Double.TryParse(s, NumberStyles.Any, ci, out number)
            {
                return false;
            }
        }
        return true;
    }
