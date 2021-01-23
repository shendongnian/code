    private void FarmCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {          
           if(e.AddedItems.Count == 1)
           {
                string selectedItem = e.AddedItems[0].ToString();
                if (selectedItem == "Temprature")
                {
                    TempLine.Visibility = Visibility.Visible;
                    MoistureLine.Visibility = Visibility.Collapsed;
                }
                else if (selectedItem  == "Moisture")
                {
                    MoistureLine.Visibility = Visibility.Visible;
                    TempLine.Visibility = Visibility.Collapsed;
                }
            }
    }
