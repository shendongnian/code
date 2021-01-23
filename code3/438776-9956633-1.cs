      private void Callout_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Activate();
        }
        public void Activate()
        {
                    //set bool activated to true
                    //make textbox visible and set focus and select all text
        }
        private void Callout_DeSelect()
        {
                //set content of callout to the textbox.Text
                //Hide textbox
                //set bool activated to false
        }
        private void this_LostFocus(object sender, RoutedEventArgs e)
        {
            Callout_DeSelect();
        }
	}
