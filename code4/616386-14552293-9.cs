    public class DeckControl : UserControl
     {
         .......
    
    
    
         // Using a DependencyProperty as the backing store for Table.  This enables animation, styling, binding, etc...
         public static readonly DependencyProperty TableProperty =
             DependencyProperty.Register("Table", typeof(TableControl), typeof(DeckControl), new UIPropertyMetadata(null));
    
         public TableControl Table
         {
             get { return (TableControl)GetValue(TableProperty); }
             set { SetValue(TableProperty, value); }
         }
     }
