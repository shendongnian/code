    public class LabCollectionManager()
    {
    
        //.................
    
        public ArrayList GetAllLabEntities()
        {
            //method that generates a generic list of LabEntity 
        }
    
        public ArrayList GetLabEntitiesByLabName(string labName)
        {
            var completeList = GetAllLabEntities();
            var filteredList = new ArrayList(completeList.Cast<LabEntity>()
                                        .Where(le => le.LabName == labName)
                                        ToList());
            return filteredList;
        }
    
        //.................
    
    }
