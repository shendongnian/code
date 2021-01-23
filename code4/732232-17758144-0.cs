    public interface IAsset : IEnumerable<IAsset>
    { 
        double GetAssetSize(); 
        void AddAsset(IAsset a); 
    }
    public class File : IAsset
    {
        ...
        public IEnumerator<IAsset> GetEnumerator()
        {
            return new IAsset[0].GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class Folder : IAsset
    {
        ...
        public IEnumerator<IAsset> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
