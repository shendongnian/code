    class Humain : Personne
    {
        public string Langue;
        public Humain(string _Name, int _Age, string _Langue) : base (_Name, _Age)
        {
            Console.WriteLine("Constrcut Humain Called\n");
            Name = _Name;
            Age = _Age;
            Langue = _Langue;
        }
    }
