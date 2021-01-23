        private int currentPassword = -1;
        private int[] passwords = new int[]{111111,222222,333333,444444,555555};
        private DateTime startTime = new DateTime(2012, 7, 18, 22, 0, 0);
        private DateTime endTime = new DateTime(2012, 7, 18, 22, 15, 0);
        private void button1_Click(object sender, EventArgs e)
        {
            if (isValidTime(DateTime.Now))
            {
                currentPassword++;
                currentPassword = currentPassword % passwords.Length;
                MessageBox.Show(passwords[currentPassword].ToString());
            }
            else
            {
                MessageBox.Show( "Try again at a different time" );
            }
        }
        private bool isValidTime( DateTime now )
        {
            if ( startTime.TimeOfDay.CompareTo(now.TimeOfDay) <= 0)
            {
                if ( now.TimeOfDay.CompareTo(endTime.TimeOfDay) <= 0)
                {
                    return true;
                }
            }
            return false;
        }
