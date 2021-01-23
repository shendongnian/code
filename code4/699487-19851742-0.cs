    public static Task<List<ILeaf>> GetLeafs(int doorID)
    {
        using (var db = new StorefrontSystemEntities())
        {
            var result = db.proc_GetDoorLeafs(doorID).ToList<ILeaf>();
            return Task.FromResult(result);
        }
    }
