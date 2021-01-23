    class Wynik
    {
        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        private int liczba;
        public int Liczba
        {
            get { return liczba; }
            set { liczba = value; }
        }
        public Wynik (int l, DateTime d)
        {
            Liczba = l;
            Data = d;
        }
    }
