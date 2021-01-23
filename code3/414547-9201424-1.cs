    private List<Dipendente> dipendenti;
    private ReadOnlyCollection<Dipendente> readOnlyDipendenti;
    public GestorePersonale()
    {
        dipendenti = new List<Dipendente>();
        readOnlyDipendenti = new ReadOnlyCollection<Dipendente>(dipendenti);
    }
    public ReadOnlyCollection<Dipendente> Dipendenti
    {
        get { return readOnlyDipendenti; }
    }
