    public static Task<List<ILeaf>> GetLeafs(int doorID)
    {
        return Task.Run(() =>
            {
                using (var db = new StorefrontSystemEntities())
                {
                    return db.proc_GetDoorLeafs(doorID).ToList<ILeaf>();
                };
            });
    }
