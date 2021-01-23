    public class RowStyle : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            // here the item property is the entity that the grid row is bound to.
            // check whatever values you want on it and locate a matching style with
            // find resource.
        
            // return a reference to the correct style here
                    
            // or allow this to run if you want the default style.
            return base.SelectStyle(item, container);
        }
    }
