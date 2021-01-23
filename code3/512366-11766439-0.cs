    public abstract class ChildCollectionGrid<TParent, TChild> : MyGridControl
    {
        public abstract ChildCollection<TParent, TChild> Collection;
        etc.
    }
    public class WidgetWafflesGrid : ChildCollectionGrid<Widget, Waffle>
    {  
    }
