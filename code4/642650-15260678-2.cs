    public IEnumerable<IEnumerable<device>> GetDevicesInChunks(int chunkSize)
    {
        using (var db = new AccountsEntities())
        {
            for (int i = 0; i < db.devices.Count(); i += chunkSize)
            {
                yield return db.devices.OrderByDescending(y => y).Skip(i).Take(chunkSize);
            }
        }
    }
