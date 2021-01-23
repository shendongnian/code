    public class WellInfo
    {
        private string[] _infos;
        public WellInfo(string[] infos)
        {
            this._infos = infos;
        }
        public string DisplayValue
        {
            get { return this._infos.Aggregate((current, next) => current + ", " + next); }
        }
    }
