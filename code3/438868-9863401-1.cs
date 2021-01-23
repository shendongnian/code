    Car car = new Car(0, OnShapeClicked);
    public void OnShapeClicked(Car car)
    {
        MessageBox.Show(car.Direction); 
    }
