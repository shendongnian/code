    public interface UIElement
    {
    }
    
    public interface IUIContainer
    {
        ICollection<IUIElement> Children;
    }
    
    public interface IUIRect
    {
        IPosition Position { get; }
        ISize Size { get; }
    }
    
    public abstract class UIElement : IUIElement
    {
    }
    
    public class Multiple : UIElement, IUIContainer, IUIRect
    {
        private readonly ISize _size;
        private readonly IPosition _position;
        private readonly List<UIElement> _children = new List<UIElement>();
    
        public Multiple()
        {
        }
    
        public IPosition Position { get { return _position; } }
        public ISize Size { get { return _size; }; }
        
        public ICollection<IUIElement> Children { get { return _children; } }
    }
