    public static bool validateName(String name)
    {
        Regex regex = new Regex("^[A-Z]");
        return regex.IsMatch(name)
    }
