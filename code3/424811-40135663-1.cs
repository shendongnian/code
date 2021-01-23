    private void ParentItem_Click(object sender, RoutedEventArgs e)
    {
         MenuItem item = e.OriginalSource as MenuItem;
         if(item == Parent)
         {
             // Handle Parent
         }
    }
    private void ChildItem_Click(object sender, RoutedEventArgs e)
    {
         MenuItem item = e.OriginalSource as MenuItem;
         if(item == Child)
         {
             // Handle Child
         }
    }
