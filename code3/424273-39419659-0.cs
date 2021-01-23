    var kisi=context.Kisi.Find(Id);
    context.Entry(kisi).State=EntityState.Deleted;
    var musteri= new Musteri()
    {
        KisiID=kisi.KisiID,
        Ad=kisi.Ad,
        Soyad=kisi.Soyad,
        Gruplar= kisi.Gruplar,
        Kampanyalar=kisi.Kampanyalar,
        Meslek="Adaskdm"
    }
    context.Entry(musteri).State=EntityState.Added;
    context.SaveChanges();
