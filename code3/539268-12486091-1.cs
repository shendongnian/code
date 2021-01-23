    public AddImportData(CustomType ModelData)
    {
        ModelData.FormatAndWriteToDB(db);
        db.SaveChanges();
    }
