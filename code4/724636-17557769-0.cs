    public static class AssociationEntityExtensions
    {
      public static List<Entity1> ToEntityList(this List<AssociationEntity> searchlist)
      {
        return searchlist.Select(x => new Entity1() 
          { 
            entity.ID = x.ID, 
            entity.NAME = x.NAME     
          })
          .ToList();
      } 
    }
