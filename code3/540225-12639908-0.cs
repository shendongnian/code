    public class PostCodeVerifyMandatory : IPostCodeVerifyMandatory
    {
        public List<Func<int, string, bool>> Rules { get; private set; }
        public PostCodeVerifyMandatory()
        {
            Rules = new List<Func<int, string, bool>>();
        }
        public bool IsPostCodeRequired(int countryId, string region)
        {
            if(Rules == null)
                return false;
            return (Rules.Any(r => r(countryId, region)));
        }
    }
