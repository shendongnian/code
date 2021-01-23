        private double voltage = 0.0D;
        public double Voltage
        {
            get
            {
                return voltage;
            }
            set
            {
                if (value > 5.0D || value < 0.0D)
                    throw new InvalidOperationException();
                voltage = value;
                OnPropertyChanged("Voltage");
            }
        }
        public string VoltageText
        {
            get
            {
                return Voltage + " V";
            }
        }
