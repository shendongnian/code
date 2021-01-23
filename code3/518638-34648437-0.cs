    TimePicker timePicker = new TimePicker()
                    {
                        Margin = new Thickness(0, 10, 0, 10)
                    }; 
					
					StackPanel myStackPanel = new StackPanel();
                    myStackPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                    myStackPanel.Children.Add(timePicker);                    
                    //Create a new custom message box
                    CustomMessageBox messageBox = new CustomMessageBox()
                    {
                        Content = myStackPanel,
                        LeftButtonContent = "Ok",
                        RightButtonContent = "Cancel",                        
                        IsFullScreen = false                        
                    };
					
					messageBox.Show();
