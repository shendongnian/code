     private void _Calendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
                {
                    if (Mouse.Captured is CalendarItem)
                    {
                        Mouse.Capture(null);
                    }
                }
