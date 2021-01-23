    public static class EntityReferenceExtensions{
        public static Guid GetIdOrDefault(this EntityReference entity){
            return (entity ?? new EntityReference()).Id;
        }
    }
