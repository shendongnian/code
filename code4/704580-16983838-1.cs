    public static class EntityReferenceExtensions{
        public static Guid GetIdOrDefault(this EntityReference entity){
            if(entity == null){
                return Guid.Empty;
            } else {
                return entity.Id;
            }
        }
    }
