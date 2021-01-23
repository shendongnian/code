    public async Task<YourTable> Find(string id)
        {
            ObjectId internalId = GetMongoId.GetInternalId(id);
            return await YourContext.YourTable.Find(c => c.InternalId == internalId).FirstOrDefaultAsync();
        }
