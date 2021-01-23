    public static void Order<IBusinessEntity> (List<IBusinessEntity> filteredList, List<IBusinessEntity> fullList)
    {
        //Getting list of ID from all business entities.
        HashSet<long> ids = new HashSet<long>(filteredList.Select(x => x.ID));
        //Ordering the list
        return fullList.OrderByDescending(x => ids.Contains(x.ID)).ThenBy(x => !ids.Contains(x.ID)).ToList();
    }
