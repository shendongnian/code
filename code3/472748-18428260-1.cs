            public void SurahsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                string r = ((ListBox)sender).SelectedValue.ToString();
                NavigationService.Navigate(new Uri("/page.xaml?selecteItem=" + r, UriKind.Relative));
            }
