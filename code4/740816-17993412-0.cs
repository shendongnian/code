            newButton.Click += (o, ev) =>
            { 
                panelA.Visibility = System.Windows.Visibility.Hidden;
                panelB.Visibility = System.Windows.Visibility.Visible;
            }
            closeButton.Click += (o, ev) =>
            {
                panelB.Visibility = System.Windows.Visibility.Hidden;
                panelA.Visibility = System.Windows.Visibility.Visible;
            };
