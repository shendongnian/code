    class FilteredProperties<T> where T : BaseEntity
    {
         static public List<string> Values { get; private set; }
         // or static public readonly List<string> Values = new List<string>();
         static FilteredProperties()
         {
             // logic to populate the list goes here
         }
    }
