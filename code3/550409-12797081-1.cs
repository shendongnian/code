    var dynObj = (JObject)JsonConvert.DeserializeObject(json);
    var authors = dynObj["Authors"]
                    .Select(j => new AuthorDetails { 
                                RealName = (string)j["RealName"], 
                                DisplayName = (string)j["DisplayName"] 
                    })
                    .ToList();
    var countries = dynObj["Countries"]
                    .Select(j => new Country { Name = (string)j["Name"]})
                    .ToList();
    var books = dynObj["Books"].Select(x => new Book
                    {
                        Author = authors[(int)x["Author"]],
                        Title = (string)x["Title"],
                        PublishedCountries = x["PublishedCountries"].ToString().Split(',')
                                                .Select(i =>countries[int.Parse(i)])
                                                .ToList()
                    })
                    .ToList();
---
    public class Country
    {
        public string Name { get; set; }
    }
    public class AuthorDetails
    {
        public string DisplayName { get; set; }
        public string RealName { get; set; }
    }
    public class Book
    {
        public AuthorDetails Author { get; set; }
        public string Title { get; set; }
        public List<Country> PublishedCountries { get; set; }
    }
