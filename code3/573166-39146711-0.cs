    var client = new RestClient("http://{URL}/rest/api/2");
    var request = new RestRequest("issue/", Method.POST);
    client.Authenticator = new HttpBasicAuthenticator("user", "pass");
    var issue = new Issue
    {
        fields =
            new Fields
            {
                description = "Issue Description",
                summary = "Issue Summary",
                project = new Project { key = "KEY" }, 
                issuetype = new IssueType { name = "ISSUE_TYPE_NAME" }
            }
    };
    request.AddJsonBody(issue);
    var res = client.Execute<Issue>(request);
    if (res.StatusCode == HttpStatusCode.Created)
        Console.WriteLine("Issue: {0} successfully created", res.Data.key);
    else
        Console.WriteLine(res.Content);
