    public class MyListBox : ListBox
    {
        public ScrollViewer ScrollViewer
        {
            get 
            {
                Border border = (Border)VisualTreeHelper.GetChild(this, 0);
                return (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
            }
        }
    }
