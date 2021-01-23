    public class BaseUserControl : UserControl
    {
        public void BaseInitComponent()
        {
            var button = this.FindName("CopyButton") as Button;
            button.Click += new System.Windows.RoutedEventHandler(Copy_Click);
        }
        void Copy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //do stuff here
        }
    }
