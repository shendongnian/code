     public class InstagramService : IInstagramService
     ...
     public InstagramConfig Config
        {
            get{return new InstagramConfig("https://api.instagram.com/v1", "https://api.instagram.com/oauth", InstagramAuthorisationModel.ApplicationId, InstagramAuthorisationModel.Secret, InstagramAuthorisationModel.RedirectUri);}
        }
      private AuthInfo UserAuthInfo()
        {
            return new AuthInfo()
             {
                 // User =new UserInfo(){},
                 Access_Token = GetInstagramAccessToken()
             };
        }
       public string GetInstagramAccessToken()
        {
            return _socialMediaRepository.GetInstagramAccessToken(_userApiKey);
        }
       public List<InstagramResult> Search(string searchTag, int count)
        {
            var auth = UserAuthInfo();
            var tags = new InstaSharp.Endpoints.Tags.Authenticated(Config, auth); 
            var searchresult = tags.Recent(searchTag);
            return searchresult.Data.Select(media => new InstagramResult()
            {
                Media = media,
                image = media.Images.LowResolution.Url
            })
            .ToList();
        }
..
