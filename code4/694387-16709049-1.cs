        private readonly IAdder _adder = new ConreteAdder();
        private void NumberChanged() //Call this method within the properties you want to create the mathematical equation with
        {
            Change = _adder.Add(Payment, Total); //Or whatever method you want
        }
    
        public event PropertyChangedEventHandler PropertyChanged2;
  
        private void OnResultChanged()
        {
            var handler = PropertyChanged2;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs("Result"));
        }
