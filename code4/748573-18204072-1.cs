    private void gobut_Click(object sender, RoutedEventArgs e)
            {
                int num = 0;
    
                if (int.TryParse(txtbx.Text, out num) && num > 0 && num < 115)
                {
                    string site;
                    site = num.ToString();
                    NavigationService.Navigate(new Uri("/Page" + site + ".xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Enter Value between 1 to 114");
                }
            } 
