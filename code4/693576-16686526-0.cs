    public class RadScrollIntoViewBehavior : Behavior<RadGridView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += new EventHandler<SelectionChangeEventArgs>(AssociatedObject_SelectionChanged);
        }
        void AssociatedObject_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (sender is RadGridView)
            {
                RadGridView grid = (sender as RadGridView);
                if (grid.SelectedItem != null)
                {
                    grid.UpdateLayout();
                    grid.ScrollIntoView(grid.SelectedItem, null);
                }
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= new EventHandler<SelectionChangeEventArgs>(AssociatedObject_SelectionChanged);
        }
    }
    <telerik:RadGridView>
       <i:Interaction.Behaviors>
                    <my3:RadScrollIntoViewBehavior />
                </i:Interaction.Behaviors> 
                    <telerik:RadGridView.Columns>
                         <telerik:GridViewDataColumn Name="example"/>
                    </telerik:RadGridView.Columns>
    </telerik:RadGridView>
