    namespace YourNamespace // wrap that into e.g. 'xmlns:local="clr-namespace:YourNamespace"'
    public static class Attach
    {
        public static ICommand GetAutoGenerateColumnEvent(DataGrid grid) { return (ICommand)grid.GetValue(AutoGenerateColumnEventProperty); }
        public static void SetAutoGenerateColumnEvent(DataGrid grid, ICommand value) { grid.SetValue(AutoGenerateColumnEventProperty, value); }
        public static readonly DependencyProperty AutoGenerateColumnEventProperty =
            DependencyProperty.RegisterAttached("AutoGenerateColumnEvent", typeof(ICommand), typeof(Attach), new UIPropertyMetadata(null, OnAutoGenerateColumnEventChanged));
        static void OnAutoGenerateColumnEventChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            DataGrid grid = depObj as DataGrid;
            if (grid == null || e.NewValue is ICommand == false)
                return;
            ICommand command = (ICommand)e.NewValue;
            grid.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>((s, args) => OnAutoGeneratingColumn(command, s, args));
            // handle unsubscribe if needed
        }
        static void OnAutoGeneratingColumn(ICommand command, object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (command.CanExecute(e)) command.Execute(e);
        }
    }
