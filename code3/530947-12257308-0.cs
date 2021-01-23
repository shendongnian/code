    public interface IPluginTypeVisitor
    {
        void Visit(AcceptedType type);
    }
    
    public interface IQueryPlugin
    {
        string PluginCategory { get; }
        string Name { get; }
        string Version { get; }
        string Author { get; }
        void VisitTypes(IPluginTypeVisitor visitor);
    }
