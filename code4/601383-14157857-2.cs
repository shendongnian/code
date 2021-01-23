    public class Profile : ProfileOverview
    {
        public Profile() { }
       ... (some properties and fields)
    }
    public class ProfileHelper
    {
        public Profile LoadProfileById(long ProfileId)
        {
            using (System.Data.IDbCommand cmd = Settings.DAL.CreateCommand("SELECT * FROM Profiles WHERE ProfileId = @__in_profileid"))
            {
                Settings.DAL.AddParameter(cmd, "__in_profileid", ProfileId);
                return Settings.DAL.GetClass<Models.Profile>(cmd);
            }
        }
    }
