    class Car
    {
        private int _fuel;
        public int Fuel
        {
            get { return _fuel;}
            set
            {
                if(_fuel != value)
                {
                    _fuel = value;
                    var t = TankEmpty;
                    if(t != null)
                    {
                        t(this, EventArgs.Empty);
                    }
                }
            }
         }
    
         public event EventHandler TankEmpty; 
    }
    
    
    class Driver
    {
        private Car _car;
    
        Driver(Car car)
        {
            _car = car;
            _car.TankEmpty += Car_TankEmpty;
        }
    
        private void CarTank_Empty(object sender, EventArgs e)
        {
            //Push Car
        }
    }
