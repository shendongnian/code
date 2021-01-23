    public class Profile
    {
        string profileName = "";
        string imageSource = "/Resources/Delete.png";
        public string ProfileName
        {
            get
            {
                return profileName;
            }
            set
            {
                profileName = value;
            }
        }
        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
            }
        }
        public Profile(string name)
        {
            ProfileName = name;
        }
    }
