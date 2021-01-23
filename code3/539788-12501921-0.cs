        private static IQueryable<SomeEntity> OrderByName(IQueryable<SomeEntity> source, string culture)
        {
            if (culture == "fr-CA")
            {
                return source.OrderBy(x => x.Name.FrenchValue);
            }
            return source.OrderBy(x => x.Name.EnglishValue);
        }
