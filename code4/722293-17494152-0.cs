    public static class MyExtensionMethods
    {
      public IQueryable<T> FilterDeleted(this IQueryable<T> src) where T : IHaveIsDeleted
      {
        return src.Where(x => !x.IsDeleted);
      }
    }
