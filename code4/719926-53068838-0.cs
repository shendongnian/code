    public List<Cert> List()
    {
        return db.Certs.ToList();
    }
    public static List<Cert> All()
        {
        return new CertsController().List();
    }
