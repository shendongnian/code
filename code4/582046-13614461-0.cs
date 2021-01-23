    public interface ISelectable
    {
       pubilc bool IsSelected { get; }
    }
    
    public class ItemType<T> : ISelectable
    {
       ...
    }
    
    var objects = Source.SourceCollection
       .OfType<ISelectable>()
       .Where(t => t.IsSelected);
