    public interface IDataModelExample
    {
        string Name { get; set; }
        string Value { get; set; }
        string Extension { get; set; }
    }
    public class DataModelExampleMerger
    {
        public IDataModelExample Merge(IDataModelExample dme)
        {
            var cachedDme = LoadFromCache(); // This would require the key of course.
                                             // I'll leave the implementation up to 
                                             // you.
            if (string.IsNullOrEmpty(dme.Name))
            {
                dme.Name = cachedDme.Name;
            }
            // Repeat similar if-block for all properties.
            return dme;
        }
    }
