        public static bool isCurrenctDateBetween(DateTime fromDate, DateTime toDate)
        {
            DateTime curent = DateTime.Now.Date;
            if (fromDate.CompareTo(toDate) >= 1)
            {
                MessageBox.Show("From Date shouldn't be grater than To Date", "DateRange",MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
            int cd_fd = curent.CompareTo(fromDate);
            int cd_td = curent.CompareTo(toDate);
            if (cd_fd == 0 || cd_td == 0)
            {
                return true;
            }
            if (cd_fd >= 1 && cd_td <= -1)
            {
                return true;
            }
            return false;
        }
