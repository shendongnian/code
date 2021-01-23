    Page currentPage;
    private void button12_MouseDown(object sender, MouseButtonEventArgs e) // Back to choose story menu page.
    {
        stackPanelHome.Visibility = System.Windows.Visibility.Hidden;
        pageTransition1.Visibility = System.Windows.Visibility.Visible;
        if(currentPage != null)
        {
            pageTransition1.ShowPage(currentPage);
        }
    }
    private void button2_MouseDown(object sender, MouseButtonEventArgs e) // Food fit for a king.
    {
        FoodKing controlpage = new FoodKing(); // Calling user control page          
        stackPanelHome.Visibility = System.Windows.Visibility.Hidden;
        pageTransition1.Visibility = System.Windows.Visibility.Visible;
        pageTransition1.ShowPage(controlpage); 
        currentPage = controlpage;
    }
    private void button1_MouseDown(object sender, MouseButtonEventArgs e) // Grasshopper
    {
        GrasshopperMenu controlpage = new GrasshopperMenu(); // Calling user control page
        stackPanelHome.Visibility = System.Windows.Visibility.Hidden;
        pageTransition1.Visibility = System.Windows.Visibility.Visible;
        pageTransition1.ShowPage(controlpage); 
        currentPage = controlpage;
    }
