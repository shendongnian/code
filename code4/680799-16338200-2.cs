            foreach(Image item in (sender as Grid).Children)
            {
                if(item.Visibility == Visibility.Visible)
                    item.Visibility = Visibility.Collapsed;
                else
                    item.Visibility = Visibility.Visible;
            }
