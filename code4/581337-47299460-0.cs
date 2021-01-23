    public class ExposesReadOnly
    {
        private Dictionary<int, NotReadOnly> InternalDict { get; set; }
        public Func<int,IReadOnly> PublicDictionaryAccess
        {
            get
            {
                return (x)=>this.InternalDict[x];
            }
        }
        // This class can be modified internally, but I don't want
        // to expose this functionality.
        private class NotReadOnly : IReadOnly
        {
            public string Name { get; set; }
        }
    }
    public interface IReadOnly
    {
        string Name { get; }
    }
