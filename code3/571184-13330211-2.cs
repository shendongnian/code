    IEnumerable<Pet> FindPetsMatchingCustomerCriteria(CustomerPetSearchCriteria customerSearchCriteria)
    {
        return repository.GetAllPetsLinkedCriteria()
                         .Where(x => 
                          Check(x.TypeID, customerSearchCriteria.TypeID) &&
                          Check(x.FeedingMethodID, customerSearchCriteria.FeedingMethodID) &&
                          Check(x.FlyAblityID, customerSearchCriteria.FlyAblityID) &&
                          Check(x.LocationID, customerSearchCriteria.LocationID))
                         .Select(x => x.Pet);
    }
    static bool Check(int petProperty, int searchCriteriaProperty)
    {
        return searchCriteriaProperty == 0 || petProperty == searchCriteriaProperty;
    }
