    public static bool IsSchoolYearFormat(string format, int minYear, int maxYear)
    {
        string[] parts = format.Trim().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2)
        {
            int fromYear; int toYear;
            if (int.TryParse(parts[0], out fromYear) && int.TryParse(parts[1], out toYear))
            {
                if (fromYear >= minYear && toYear <= maxYear && fromYear + 1 == toYear)
                    return true;
            }
        }
        return false;
    }
