    public Area FindArea(string id)
    {
      // First see if the DbSet already has it in the local cache
      Area area = context.Areas.Local.SingleOrDefault(x => x.Id == id);
      // Then query the database
      return area ?? context.Areas.SingleOrDefault(x => x.Id == id);
    }
