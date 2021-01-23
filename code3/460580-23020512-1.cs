    "asdfasdf".ContainsAny(".","/","4");
    public static bool ContainsAny(this string stringToCheck, params string[] parameters)
    {
        return parameters.Any(parameter => stringToCheck.Contains(parameter));
    }
