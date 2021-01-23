    public interface ISomeDataBlob
    {
    }
    
    internal class SomeDataBlob : ISomeDataBlob
    {
    }
    
    public class BlobApiFactory
    {
        ISomeDataBlob Create();
    }
