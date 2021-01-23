    public interface ExternalPlugin
    {
        void DoStuff(ISomeDataBlob blob);
    }
    // Interfaces:
    public interface IDataBlob
    {
        string Prop { get; }
    }
    public interface IDataBlobV2 : IDataBlob
    {
        string Prop2 { get; }
    }
    // Data blob for v1 of API
    internal class SomeDataBlob : IDataBlob
    {
        internal SomeDataBlob(string prop) { Prop = prop; }
        public string Prop { get; private set; }
    }
    // FUTURE!
    // Data blob API v2 of API
    public class SomeDataBlobV2 : SomeDataBlob, IDataBlobV2
    {
        // Can be passed to clients expecting SomeDataBlob no problem.
        internal SomeDataBlobV2(string prop, string prop2) : base(prop) { Prop2 = prop2; }
        public string Prop2 { get; private set; }
    }
