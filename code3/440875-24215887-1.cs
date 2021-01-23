    public class AccessTokenModel
    {
    	public string Access_Token { get; set;}
    }
    
    var fb = new FacebookClient();
    var result = fb.Get ("oauth/access_token", new { 
    	client_id     = App.FaceBookId, 
    	client_secret = App.FacebookAppSecret, 
    	grant_type    = "client_credentials" 
    });
    var accessToken = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessTokenModel> (result.ToString ());
