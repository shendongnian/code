    public async void button1_Click(object sender, EventArgs args)
    {
        await Task.Delay(1000);
        GotoMeasurementMode(3000);
        await Task.Delay(3000);
        query(device.Text);
        await Task.Delay(7000);
        StopMeasurement();
        await Task.Delay(4000);
    }
