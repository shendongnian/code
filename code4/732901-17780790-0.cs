    class FilteredProperties<T> where T : BaseEntity
    {
         static public List<string> Values { get; private set; }
         static FilteredProperties()
         {
             // logic to populate the list goes here
         }
    }
