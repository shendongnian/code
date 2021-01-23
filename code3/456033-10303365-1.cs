    private void testClick_Click(object sender, RoutedEventArgs e)
        {
            TestFunction(sender as Button);
        }
    
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
             //Call same function as button
             TestFunction(testClick);
        }
    
    private void TestFunction(Button bt)
        {
              //do stuff
        }
