            private bool _canUpdate = true; 
    
    		private bool _needUpdate = false;		
    
    		//If text has been changed then start timer
    		//If the user doesn't change text while the timer runs then start search
    		private void combobox1_TextChanged(object sender, EventArgs e)
            {
                if (_needUpdate)
                {
                    if (_canUpdate)
                    {
                        _canUpdate = false;
                        UpdateData();					
                    }
                    else
                    {
                        RestartTimer();
                    }
                }
            }
    		private void UpdateData()
    		{
    			if (combobox1.Text.Length > 1)
    			{
    				List<string> searchData = Search.GetData(combobox1.Text);
    				HandleTextChanged(searchData);
    			}
    		}		
    		
    		//If an item was selected don't start new search
    		private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                _needUpdate = false;
            }
    
    		//Update data only when the user (not program) change something
    		private void combobox1_TextUpdate(object sender, EventArgs e)
            {
                _needUpdate = true;
            }
    		
    		//While timer is running don't start search
    		//timer1.Interval = 1500;
    		private void RestartTimer()
            {
                timer1.Stop();
                _canUpdate = false;
                timer1.Start();
            }
    		
    		//Update data when timer stops
    		private void timer1_Tick(object sender, EventArgs e)
            {
                _canUpdate = true;
                timer1.Stop();
                UpdateData();
            }
    		
    		//Update combobox with new data
    		private void HandleTextChanged(List<string> dataSource)
            {
                var text = combobox1.Text;
    
                if (dataSource.Count() > 0)
                {
                    combobox1.DataSource = dataSource;  
                   
                    var sText = combobox1.Items[0].ToString();
                    combobox1.SelectionStart = text.Length;
                    combobox1.SelectionLength = sText.Length - text.Length;
                    combobox1.DroppedDown = true;
                    
    
                    return;
                }
                else
                {
                    combobox1.DroppedDown = false;
                    combobox1.SelectionStart = text.Length;
                }
            }
