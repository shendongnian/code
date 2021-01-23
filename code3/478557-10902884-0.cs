     private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 1; i < 3; i++)
            {
               PrintDialog dialog = new PrintDialog();
                //showing this message box fixes the issue
                //MessageBox.Show("01");
                updateTextblock(i);
    
                //use the dispatcher object to ensure all renders and databinding are completed before sending to print   
                Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(delegate
                {
                    print(dialog);
                }
                ));   
            }
        }
