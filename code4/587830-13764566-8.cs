    public int AvailableCups {
        get {
            lock (_lock) {
                return GetAvailableCups(_coffeeHandle); // P/Invoked
            }
        }
    }
    public void Dispense(int nCups)
    {
        lock (_lock) {
            int nAvail = GetAvailableCups(_coffeeHandle);
            if (nAvail < nCups) throw new CoffeeException("not enough coffee.");
            Dispense(_coffeeHandle, nCups); // P/Invoked
        }
     }
