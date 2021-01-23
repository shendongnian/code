    public class Profile : ProfileOverview
    {
        public Profile()
        { }
        public static Profile Get(long ProfileId)
        {
            using (System.Data.IDbCommand cmd = Settings.DAL.CreateCommand("SELECT * FROM Profiles WHERE ProfileId = @__in_profileid"))
            {
                Settings.DAL.AddParameter(cmd, "__in_profileid", ProfileId);
                return Settings.DAL.GetClass<Models.Profile>(cmd);
            } // End Using cmd
        }
       ... (some properties and fields)
    }
