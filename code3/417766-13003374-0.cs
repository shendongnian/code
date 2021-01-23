    private bool CheckIfEntityRecordExists(Entity e)
    {
        var retVal = false;
        using (var db = new EntityContext())
        {
            retVal = db.AdviserClients.Any(a => a.Id == e.Id);
        }
        return retVal;
    }
