      public class DataGridWrapTextBehaviour : Behavior<DataGrid>
      {
         private DataGrid DataGrid
         {
            get { return AssociatedObject as DataGrid; }
         }
         private Style ElementStyle { get; set; }
         private Style EditingElementStyle { get; set; }
         protected override void OnAttached()
         {
            base.OnAttached();
            this.ElementStyle = new Style( typeof( TextBlock ) );
            this.ElementStyle.Setters.Add( new Setter( TextBlock.TextWrappingProperty, TextWrapping.Wrap ) );
            this.EditingElementStyle = new Style( typeof( TextBox ) );
            this.EditingElementStyle.Setters.Add( new Setter( TextBox.TextWrappingProperty, TextWrapping.Wrap ) );
            this.DataGrid.Columns.CollectionChanged += Columns_CollectionChanged;
         }
         protected override void OnDetaching()
         {
            this.DataGrid.Columns.CollectionChanged -= Columns_CollectionChanged;
            base.OnDetaching();
         }
         private void Columns_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
         {
            foreach ( var column in this.DataGrid.Columns.OfType<DataGridTextColumn>() )
            {
               column.ElementStyle = this.ElementStyle;
               column.EditingElementStyle = this.EditingElementStyle;
            }
         }
      }
