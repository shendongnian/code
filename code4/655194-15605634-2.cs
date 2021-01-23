    String[] newData = SensorData.Split(new[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
    for(int i=0; i<newData.Length; i++)
    {
        textBox1.Text = newData[i]; // You will need to manipulate the textboxes better here, since the
    }
