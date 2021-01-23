    if (file != null && file.ContentLength > 0)
    {
        BinaryReader b = new BinaryReader(file.InputStream);
        byte[] binData = b.ReadBytes((int)file.InputStream.Length);
        var customerDoc = new CustomerDoc { CustomerID = customer.CustomerID, Document = binData };
        db.Entry(customerDoc).State = EntityState.Modified;
        db.SaveChanges();
    }
