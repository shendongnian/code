    static class Extns
    {
        public static IEnumerable<T> WhereZeroOr<T>(this IEnumerable<T> items, Func<T, int> idAccessor, int id)
        {
            if (id == 0)
                return items;
            else
                return items.Where(x => idAccessor(x) == id);
        }
    }
    private PetsRepository repository = new PetsRepository();
    public IEnumerable<Pet> FindPetsMatchingCustomerCriteria(CustomerPetSearchCriteria customerSearchCriteria)
    {
        return repository.GetAllPetsLinkedCriteria()
            .WhereZeroOr(x => x.TypeID, customerSearchCriteria.TypeID)
            .WhereZeroOr(x => x.FeedingMethodID, customerSearchCriteria.FeedingMethodID)
            .WhereZeroOr(x => x.FlyAblityID, customerSearchCriteria.FlyAblityID)
            .WhereZeroOr(x => x.LocationID, customerSearchCriteria.LocationID);
    }
