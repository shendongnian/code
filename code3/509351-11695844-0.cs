        public long GetIdCompany(long number)
        {
            Equipament equipamentAlias = null;
            return session.QueryOver<Report>()
                          .Where(x => x.Number == number)
                          .JoinAlias(x => x.Equipament, () => equipamentAlias)
                          .Select(x => equipamentAlias.Company.Id)
                          .SingleOrDefault<long>();
        }
