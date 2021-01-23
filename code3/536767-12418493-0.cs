    private void checkedChanged(object sender, RoutedEventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        int index;
        if (int.TryParse(cb.Tag.ToString(), out index))
        {
            if (cb.IsChecked == true)
            {
                switch (index)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            else if (cb.IsChecked == false)
            {
                switch (index)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (index)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
    }
