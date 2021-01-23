    public class LabCollectionManager()
    {
    
        //.................
    
        public List<LabEntity> GetAllLabEntities()
        {
            //method that generates a generic list of LabEntity 
        }
    
        public List<LabEntity> GetLabEntitiesByLabName(string labName)
        {
            return GetAllLabEntities().Where(le => le.LabName == labName).ToList();
        }
    
        //.................
    
    }
