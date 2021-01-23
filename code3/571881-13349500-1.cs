    private Car _car = new Car("","",0)
    private void accButton_Click(object sender, EventArgs e)
    {
         _car.Accelerate();
         currentspeedListBox.Items.Add(car.Speed.ToString());
    }
