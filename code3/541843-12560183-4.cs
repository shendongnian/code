    public byte[] GetImage(string id)
    {
        using (var db = new SomeDataContext())
        {
            return db.Images.FirstOrDefault(x => x.Id == id).ImageData;
        }
    }
