    public class Country
    {
        public Country()
        {
            States = new List<State>();
        }
        public int         CountryID  { get; set; }
        public List<State> States     { get; set; }
    }
    public class State
    {
        public int    StateID    { get; set; }
        public string StateName  { get; set; }
    }
