      Console.WriteLine(Localize("name", "ro"));
      Console.WriteLine(Localize("name", "en"));
      Console.WriteLine(Localize("name", "fr"));
      Console.WriteLine(Localize("name", "tr"));
    public static string Localize(string name, string languageCode)
    {
      return Strings.ResourceManager.GetString(name, new CultureInfo(languageCode));
    }
