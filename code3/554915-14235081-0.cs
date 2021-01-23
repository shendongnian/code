    public sealed class Favorites : ApplicationSettingsBase
    {
        public Favorites()
        {
            this.FavoritesList = new List<Favorite>();
        }
    
        [UserScopedSetting]
        public List<Favorite> FavoritesList
        {
            get
            {
                return (List<Favorite>)this["FavoritesList"];
            }
            set
            {
                this["FavoritesList"] = value;
            }
        }
    }
    
    [Serializable]
    public class Favorit
    {
        // ...
    }
