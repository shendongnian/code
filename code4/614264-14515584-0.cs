    public interface IMetadataDifference
    {
        object NewMetadata { get; }
        object OldMetadata { get; }
    }
    public interface IMetadataDifference<out T> : IMetadataDifference
    {
        new T NewMetadata { get; }
        new T OldMetadata { get; }
    }
    public class MetadataDifference<T> : IMetadataDifference<T>
    {
        object IMetadataDifference.NewMetadata { get { return NewMetadata; } }
        object IMetadataDifference.OldMetadata { get { return OldMetadata; } }
        public T NewMetadata { get; private set; }
        public T OldMetadata { get; private set; }
        // Other useful properties
        public MetadataDifference(T newMetadata, T oldMetadata)
        {
            NewMetadata = newMetadata;
            OldMetadata = oldMetadata;
        }
    }
    public class DifferencesResult
    {
        public IEnumerable<IMetadataDifference> MetadataChanges { get; set; }
        // other fields
    }
