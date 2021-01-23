        public InstagramConfig Config 
        {
            get
            {
                return new InstagramConfig(InstagramAuthorisationModel.ApplicationId, InstagramAuthorisationModel.Secret);
            }
        }
    public void YourSubscribeMethod(string searchTerm)
    {
        var result = await new Subscription(Config).CreateTag(searchTerm))
    }
