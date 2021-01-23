    override NotchsList11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = NotchsList11.Items[NotchsList11.SelectedIndex] as YourClassUsedForBinding;
            if(item.SomeProperty == "Something")
            NavigationService.Navigate(new Uri("/YourNewPage.xaml", UriKind.Relative));
            else
            NavigationService.Navigate(new Uri("/YourOtherPage.xaml", UriKind.Relative));
            //if more cases use a switch case
        }
