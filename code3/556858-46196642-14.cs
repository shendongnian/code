    private void InitializeNetworkInterface()
            {
                // Grab all local interfaces to this computer
                nicArr = NetworkInterface.GetAllNetworkInterfaces();
    
                // Add each interface name to the combo box
                for (int i = 0; i < nicArr.Length; i++)
                    comboBox1.Items.Add(nicArr[i].Name); //you add here the interface types in a combobox and select from here WiFi, ethernet etc...
    
                // Change the initial selection to the first interface
                comboBox1.SelectedIndex = 0;
            }
            private void InitializeTimer()
            {
                timer = new Timer();
                timer.Interval = (int)timerUpdate;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
