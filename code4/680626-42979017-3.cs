           var cr = JsonConvert.DeserializeObject<PersonalServiceAccountCred>(json); 
           // "personal" service account credential
           // Create an explicit ServiceAccountCredential credential
           var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(cr.ClientEmail)
                    {
                        Scopes = new[] { YouTubeService.Scope.YoutubeUpload /*Here put scope tha you want use*/}
                    }.FromPrivateKey(cr.PrivateKey));
