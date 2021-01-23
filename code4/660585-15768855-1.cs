    private void Calendar_KeyDown(object sender, KeyEventArgs e)
            {
                Calendar c = sender as Calendar;
                Debug.Assert(c != null, "The Calendar should not be null!");
    
                if (!e.Handled && (e.Key == Key.Enter || e.Key == Key.Space || e.Key == Key.Escape) && c.DisplayMode == CalendarMode.Month)
                {
                    this.Focus();
                    this.IsDropDownOpen = false;
    
                    if (e.Key == Key.Escape)
                    {
                        this.SelectedDate = this._onOpenSelectedDate;
                    }
                }
            }
