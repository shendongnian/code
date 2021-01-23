    private void ListUI_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(ListUI.SelectedItems.Count != 0)
            {
                Debug.WriteLine("It's not a trap at all my friend");
            }
            else
            {
                Debug.WriteLine("Its a trap");
            }
        }
