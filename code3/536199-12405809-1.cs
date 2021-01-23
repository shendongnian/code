    public class TrackSelectionStyleSelector: StyleSelector
    {
       public Style ItemsStyle {get; set;}
       public Style TrackSelectedStyle {get; set;}
       public override Style SelectStyle( object item, DependencyObject container )
       {
         if ( /* isTrackSelected logic */ )
            return TrackSelectedStyle;
         return ItemsStyle;
       }
    
    }
