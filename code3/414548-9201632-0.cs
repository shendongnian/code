        private List<Dipendente> dipendenti = new List<Dipendente>();
        public ReadOnlyCollection<Dipendente> ReadOnlyDipendenti
        {
            get
            {
                return dipendenti.AsReadOnly(); 
            }
        }
