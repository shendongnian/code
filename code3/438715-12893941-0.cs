    enter code here DateTime selectedDate = Convert.ToDateTime(dtpExpireDate.Value);
            DateTime todayDate = Convert.ToDateTime(DateTime.Now);
            if (selectedDate < todayDate)
            {
                MessageBox.Show("Selected date Must be greater then Today's date");
            }`enter code here`
