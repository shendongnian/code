    class Vehicle
    {
        public Vehicle()
        {
            LoadVehicleParameters();
        }
        virtual void ReloadParameters()
        {
            LoadVehicleParameters();
        }
        private void LoadVehicleParameters();
        {
             //logic here.
        }
    }
    class Car : Vehicle
    {
        public Car() // call to base constructor is implicit
        {
            LoadCarParameters();
        }
        virtual void ReloadParameters()
        {
            base.ReloadParameters();
            LoadCarParameters();
        }
        private void LoadCarParameters();
        {
             //logic here.
        }
    }
