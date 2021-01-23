        public IList<Country> GetAll(string culture)
        {
            var countryLanguageValue = new CountryTranslation();
            IList<Country> results = UnitOfWork.CurrentSession.QueryOver<Country>()
                .Fetch(x => x.Translations).Eager
                .JoinAlias(q => q.Translations, () => countryLanguageValue, JoinType.LeftOuterJoin)
                .Where(() => countryLanguageValue.Culture == culture)
                .OrderBy(x => x.DisplayOrder).Asc
                .List();
            return results;
        }
        public Country GetCountryByIsoCode(string isoCode)
        {
            var result = UnitOfWork.CurrentSession.QueryOver<Country>()
                .Where(x => x.IsoCode == isoCode)
                .List()
                .FirstOrDefault();
            return result;
        }
