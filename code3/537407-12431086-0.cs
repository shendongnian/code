    public bool CheckSomething(RestClient restClient)
    {
        var request = new RestRequest("resourceX/{name}", Method.GET);
        request.AddUrlSegment("name", "ABC");
        var response = client.Execute(request);
        if (response.StatusCode == HttpStatusCode.NotFound) return false;
        if (response.StatusCode == HttpStatusCode.OK) return true;
        throw new Exception("Something is messed up");
    }
