    pubic class MyPage
    {
        public MyPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    
        private void OpenVehicleClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(VehicleID != null ? VehicleID.WhateverProperty : "Nothing selected");
        }
    
        public MyDataObject VehicleID { get; set; }
    } 
