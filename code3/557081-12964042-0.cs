        IsDate(txtYearMark.Text);
        public static bool IsDate(string date)
        {
            DateTime Temp;
            return(DateTime.TryParse(date, out Temp)&&date.Length>=10)
        }
