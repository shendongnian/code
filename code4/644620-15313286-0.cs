    public static bool VerifyKey(string apiKey)
    {
        return section.Value.Cast<ClientSection.ClientElement>()
               .Any(ce => ce.ApiKey == apiKey);
    }
