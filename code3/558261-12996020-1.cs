    Set(l => l.Gebruikers, map =>
    {
        map.Table("LijstGebruiker");
        map.Cascade(Cascade.All);
        map.Key(k => k.Column("Lijst"));
    }, map => map.ManyToMany(p =>
    {
        p.Columns(x => x.Name("Gebruiker"));
    }));
