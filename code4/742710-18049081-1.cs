    public static PrasanjaViewModel GetPrasanje()
    {
        var prasanje = new PrasanjaViewModel();
        SQLiteConnection db = new SQLiteConnection(App.DB_PATH);
        var query = db.Table<Prasanja>().Where(x => x.id == 3);
        var result = query.ToList();
        foreach (var item in result)
        {
            // You probably want pradanje to have a collection property you add to, instead
            // of the a simple Id and Tekst property.
            prasanje.id = item.id;
            prasanje.Tekst = item.Tekst;
        }
        return prasanje;
    }
