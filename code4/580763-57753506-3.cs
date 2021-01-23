    public class ColumnHeaderBehaviour : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratingColumn += OnGeneratingColumn;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratingColumn -= OnGeneratingColumn;
        }
        private static void OnGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs eventArgs)
        {
            if (eventArgs.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                eventArgs.Column.Header = descriptor.DisplayName ?? descriptor.Name;
            }
            else
            {
                eventArgs.Cancel = true;
            }
        }
    }
