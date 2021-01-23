    public class MyTabItem : TabItem
        {
    
            protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
            {
                this.Background = Brushes.Yellow;
                base.OnMouseRightButtonDown(e);
            }       
        }
