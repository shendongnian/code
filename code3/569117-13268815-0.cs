        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew( () => GetCurrentDate() );
        }
    
        private void GetCurrentDate()
        {
            if ( DateTime.Today.Day == 7 && myDateToggle == false )
            {
                Task.Factory.StartNew( () => RunMonthBackUp());
            }
            else if ( DateTime.Today.Day == 8 && myDateToggle == true )
            {
                myDateToggle = false;
            }
        }
