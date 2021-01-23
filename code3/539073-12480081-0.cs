            private void one_Click(object sender, RoutedEventArgs e)
            {
                Button btn = (Button)sender;
                Int32 num;
                switch (btn.Name)
                {
                    case "one":
                        num = 1;
                        break;
                    case "two":
                        num = 2;
                        break;
                    default:
                        // problem
                }
                if (PIN > 1000)   // logic
                // no you have you num and can deal with the logic in one click event;
                PIN = (PIN * 10) + num;
                if (PIN = correctPIN)
                {
                }
                else
                {
                }          
            }
