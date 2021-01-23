    private bool CheckIfEntityRecordExists(Entity e)
    {
        var retVal = false;
        using (var db = new EntityContext())
        {
            retVal = db.AdviserClients.Count(a => a.Id == e.Id) > 0;
        }
        return retVal;
    }
