    public async Task SaveAsync(XElement xml, string filename)
    {
        await Task.Factory.StartNew(delegate
        {
            using (var fs = new FileStream("myFile", FileMode.Create))
            {
                xml.Save(fs);
            }
        });
    }
