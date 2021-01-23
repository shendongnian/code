    public static PrasanjaViewModel GetPrasanje()
    {
        var prasanje = new PrasanjaViewModel();
        SQLiteConnection db = new SQLiteConnection(App.DB_PATH);
        var result = db.Table<Prasanja>().Where(x => x.id == 3).Single();
        prasanje.id = result.id;
        prasanje.Tekst = result.Tekst;
        return prasanje;
    }
