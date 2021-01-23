        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Capture all buttons of this form.
            findButtons(this);
        }
        public void findButtons(FrameworkElement parent)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            
            for(int i=0; i<childCount; i++){
                var child = VisualTreeHelper.GetChild(parent,i);
                if (child is Button){
                      ((Button)child).Click += All_Button_Click;
                }
                
                var frameworkElement = child as FrameworkElement;
                findButtons(frameworkElement);
            }
        }
        private void All_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Generic Handler");
        }
