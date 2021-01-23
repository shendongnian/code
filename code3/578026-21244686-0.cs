    private void button1_Clicked(object sender, EventArgs e)
        {
              string serial;
              android = AndroidController.Instance;
              android.UpdateDeviceList();
              serial = android.ConnectedDevices[0];
              device = android.GetConnectedDevice(serial);
              // this will give the lable lblsomelabel the Value of the device battery level.
              lblsomelabel.Text = device.Battery.Level.ToString();
              lblsomelabel.Text += "%";
        }
