        private void DS_Loaded(object sender, RoutedEventArgs e)
        {
            ToggleButton tg = sender as ToggleButton;
            if (//WhateverYourPathToTheVariable//.DriveOnRight == "True")
            {
                tg.Content = "DS"; 
            }
            else
            {
                tg.Content = "PS";
            }
        }
