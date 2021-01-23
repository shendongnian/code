    public interface IGitHubApi {
            [Get("/users/{user}")]
            Task<User> GetUser(string user); } The RestService class generates an implementation of IGitHubApi that uses HttpClient to make its calls:
        
    var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
        
    var octocat = await gitHubApi.GetUser("octocat");
