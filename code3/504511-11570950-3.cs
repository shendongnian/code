    public sealed class Languages
        {
            public static List<Language> GetLanguages()
            {
                return new List<Language>
                {
                    new Language{Code="en",Name="English"},
                    new Language{Code="de",Name="German"},
                };
            }
        }
