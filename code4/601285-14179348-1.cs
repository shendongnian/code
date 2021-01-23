            {
                if (SecondListBox.SelectedIndex == -1)
                    return;
               ItemViewModel itemViewModel = SecondListBox.SelectedItem as ItemViewModel ;
                switch (itemViewModel.LineOne)
                {
                    case "Violet":
                        NavigationService.Navigate(new Uri("/SecondListPage1.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Indigo":
                        NavigationService.Navigate(new Uri("/SecondListPage2.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Blue":
                        NavigationService.Navigate(new Uri("/SecondListPage3.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Green":
                        NavigationService.Navigate(new Uri("/SecondListPage4.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Yellow":
                        NavigationService.Navigate(new Uri("/SecondListPage5.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Orange":
                        NavigationService.Navigate(new Uri("/SecondListPage6.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Red":
                        NavigationService.Navigate(new Uri("/SecondListPage7.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    case "Purple":
                        NavigationService.Navigate(new Uri("/SecondListPage8.xaml?selectedItem=" + SecondListBox.SelectedIndex, UriKind.Relative));
                        break;
                    default:
                        MessageBox.Show("Please Select From the list!");
                        break;
                }
                SecondListBox.SelectedIndex = -1;
            }
        }
