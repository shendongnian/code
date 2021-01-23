    class Vehicle
    {
        public string Brand { get; set; }
        public string Year { get; set; }
                            
        // GetVehicleInfo() ska returnera värdena från MyCar
        public string GetVehicleInfo()
        {
            return Brand + "\n" + Year;
        }
        
        public override string ToString() {
            return GetVehicleInfo();
        }
    }
    class Car : Vehicle
    {
        public string Kolor { get; set; }
    }
    private Car MyCar;    
    
    private void Form1_Load(object sender, EventArgs e)
    {       
        MyCar = new Car();
        MyCar.Brand = comboBoxBrand.Text;
        MyCar.Year = comboBoxYear.Text;
    }
    
    
    private void button1_Click(object sender, EventArgs e)
    {
        // comboBoxBrand.Text + "\n" + comboBoxYear.Text;
                
        myCarLabel.Text = MyCar;
        myCarLabel.BackColor = colorDialog.Color;
    }
