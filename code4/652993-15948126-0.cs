       private void NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lb = sender as ListBox;
            if (lb == null) return;
            var articleSubItem = lb.SelectedItem as NotchSubItem;
            if (articleSubItem == null)  return;
            App.CurrentArticle = articleSubItem;
            NavigationService.Navigate(new Uri("/Test.xaml?selectedItem=" + articleSubItem.ArticleId, UriKind.Relative));
            NotchsList11.SelectedIndex = -1;
        }
 
