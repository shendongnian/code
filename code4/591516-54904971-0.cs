    public static string MakeRequest(string GetCountry, string GetTime, string Server, string Database)
        {
            var filter = Builders<RequestAccess>.Filter;
            var getCountryfilter = filter.Eq(x => x.GetCountry, GetCountry);
            var getTimefilter = filter.Eq(x => x.GetTime, GetTime);
            var databasefilter = filter.Eq(x => x.Database, Database);
            var serverfilter = filter.Eq(x => x.Servers, Server);
            var makeRequest = RequestCollection.Find(filter.Or(getCountryfilter, getTimefilter, databasefilter, serverfilter)).ToList();
            return makeRequest;
        }
