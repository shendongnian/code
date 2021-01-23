        public static bool checkDate(DatePicker dpk)
        {
            TextBox tb = (TextBox)dpk.Template.FindName("PART_TextBox", dpk);
            if (dpk.SelectedDate == null)
            {
                tb.BorderThickness = new Thickness(2);
                tb.BorderBrush = Brushes.Red;
                return false;
            }
            tb.BorderThickness = new Thickness(0);
            tb.BorderBrush = Brushes.Black;
            return true;
        }
