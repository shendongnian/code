    public event EventHandler<RoutedEventArgs> OnButtonClick;
    
        public void Button_Click(object sender, RoutedEventArgs e)
                {
                    
                    if (OnButtonClick!= null){
                            OnButtonClick(sender, e);
                    }
        
                }
