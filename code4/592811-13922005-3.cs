     private void cbLang_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
            {
                ResourceDictionary dict = new ResourceDictionary();
    
                switch (((sender as ComboBox).SelectedItem as ComboBoxItem).Tag.ToString())
                {
                    case "en-US":
                        dict.Source = new Uri("Lang.en-US.xaml", UriKind.Relative);
                        break;
                    case "pl-PL":
                        dict.Source = new Uri("Lang.pl-PL.xaml", UriKind.Relative);
                        break;
                    default:
                        break;
                }
                this.Resources.MergedDictionaries.Add(dict);
            }
