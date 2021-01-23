    foreach (string tagval in tagarray)
    {
        try
        {
            var tag = new Tag
            {
                Tag1 = tagval
            };
          if(Tags.Where(e =>tag ) != null)
            {
            dataContext.AddToTags(tag);
            }
        }
        catch
        {
        }
    }
    dataContext.SaveChanges();
