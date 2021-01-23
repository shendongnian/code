     public partial class SquaresGameSample : Window
        {
            public SquaresGameSample()
            {
                InitializeComponent();
                DataContext = new SquaresGameViewModel();
            }
    
            private void OnDrop(object sender, DragEventArgs e)
            {
                var item = sender as FrameworkElement;
                if (item == null)
                    return;
    
                var square = item.DataContext as Square;
                if (square == null)
                    return;
    
                var number = (int)e.Data.GetData(typeof (int));
                square.Value = number;
            }
    
            private void OnItemMouseDown(object sender, MouseEventArgs e)
            {
                var item = sender as ListBoxItem;
                if (item == null)
                    return;
    
                DragDrop.DoDragDrop(sender as DependencyObject, item.DataContext, DragDropEffects.Move);
            }
        }
