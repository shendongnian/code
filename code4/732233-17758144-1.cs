    public interface IAsset
    { 
        double GetAssetSize(); 
        void AddAsset(IAsset a); 
        IEnumerable<IAsset> Assets { get; }
    }
    public class File : IAsset
    {
        ...
        public IEnumerator<IAsset> Assets 
        {
            get { return new IAsset[0]; }
        }
    }
    public class Folder : IAsset
    {
        ...
        public IEnumerator<IAsset> GetEnumerator()
        {
            get { return this.list; }
        }
    }
