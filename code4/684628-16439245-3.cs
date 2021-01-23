    public class LocalCrimeModel
    {
        public class Crime
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Cash { get; set; }
            public int Experience { get; set; }
        }
        public string Message { get; set; }
        public IList<Crime> Crimes { get; set; }
        public int SelectedCrimeID { get; set; }
        public Crime SelectedCrime
        {
            get
            {
                if (this.Crimes != null)
                {
                    return this.Crimes.FirstOrDefault(o => o.ID == this.SelectedCrimeID);
                }
                else
                {
                    return null;
                }
            }
        }
    }
