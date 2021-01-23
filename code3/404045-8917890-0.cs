    var client = new RestClient();
    client.BaseUrl = url;
    
    var request = new RestRequest(Method.POST);
    request.AddBody(new {
        root = new {
            request = new {
                APIClientID = 4,
                Version = 0,
                APIPassword = "password",
                Function = "TransAPIStats",
                Params = new {
                    UserId = "abc",
                    page = "example.aspx",
                    Application = "hrblock-cb",
                    Function = "ecb"
                }
            }
        }
    });
