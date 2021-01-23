    public List<Name> GetNames()
    {
        NamesModel model = new NamesModel();
        List<Name> serviceNames = model.GetNames();
        model.Close();
        return serviceNames;
    }
