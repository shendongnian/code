    public class CellTemplateDefinition
    {
        public string Key { get; set; }
        public DataTemplate ColumnTemplate { get; set;}
    }
    
    public class DynamicColumnBehavior: Behavior<GridView>
    {
         public IEnumerable<ColumnDefinition> Columns
         {
             get { return (IEnumerable<ColumnDefinition>)GetValue(ColumnsProperty); }
             set { SetValue(ColumnsProperty, value); }
         }
                
         // Using a DependencyProperty as the backing store for Columns.  This enables animation, styling, binding, etc...
         public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns", typeof(IEnumerable<ColumnDefinition>), typeof(DynamicColumnBehavior), new UIPropertyMetadata(null));
         
         public static void OnColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgsargs)
         {
             DynamicColumnBehavior behavior = sender as DynamicColumnBehavior;
             if(behavior != null) behavior.UpdateColumns();
         }
    
         public IEnumerable<CellTemplateDefinition> Cells { get; set; } 
         
         private void UpdateColumns(){ throw new NotImplementedException("I left this bit for you to do ;)");}       
    }
