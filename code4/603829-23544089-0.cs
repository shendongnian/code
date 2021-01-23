    public partial class yourPage : Page, IInvokeProvider
    {
        private void page_click_event(object sender, RoutedEventArgs e)
        {
            //do what ever you do
        }
        public void Invoke() //comes from the IInvokeProvider
        {
            Page page1 = new Page();
            page1.MouseLeftButtonDown += page_click_event;
        }
    }
