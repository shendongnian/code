    private void goButton_Click(object sender, RoutedEventArgs e)
            {
                 //Configure the ProgressBar
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
    
                //Stores the value of the ProgressBar
                double value = 0;
    
                //Create a new instance of our ProgressBar Delegate that points
                //  to the ProgressBar's SetValue method.
                UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(progressBar.SetValue);
    
                //Tight Loop:  Loop until the ProgressBar.Value reaches the max
                do
                {
                    value += 1;
    
                    /*Update the Value of the ProgressBar:
                      1)  Pass the "updatePbDelegate" delegate that points to the ProgressBar1.SetValue method
                      2)  Set the DispatcherPriority to "Background"
                      3)  Pass an Object() Array containing the property to update (ProgressBar.ValueProperty) and the new value */
                    Dispatcher.Invoke(updatePbDelegate,
                        System.Windows.Threading.DispatcherPriority.Background,
                        new object[] { ProgressBar.ValueProperty, value });
    
                }
                while (progressBar.Value != progressBar.Maximum);
            }
