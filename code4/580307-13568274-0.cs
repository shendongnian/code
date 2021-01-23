    class Profile
    {
        private const string DefaultImageSource = "/Resources/Delete.png";
        public string ProfileName { get; set; }
        public string ImageSource {get; set; }
        public Profile(string name)
        {
            ProfileName = name;
            ImageSource = DefaultImageSource;
        }
    }
