            if (!BluetoothRadio.IsSupported)
                MessageBox.Show("No Bluetooth device detected.");
            if (BluetoothRadio.PrimaryRadio.Mode == RadioMode.PowerOff)
                BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            MessageBox.Show(BluetoothRadio.PrimaryRadio.Name.ToString());
            MessageBox.Show(BluetoothRadio.PrimaryRadio.Mode.ToString());
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] info = null;
            info = bc.DiscoverDevices(999);
            foreach (BluetoothDeviceInfo device in info)
            {
                lstDevices.Items.Add(device.DeviceName + " - " + device.DeviceAddress);
                device.Update();
                device.Refresh();
                device.SetServiceState(BluetoothService.ObexObjectPush, true);
                if (!device.Authenticated){
                    // Use pin "0000" for authentication
                    if (!BluetoothSecurity.PairRequest(device.DeviceAddress, "0000")){
                        MessageBox.Show("Request failed");
                    }
                }
                var file = @"d:\1.jpg";
                var uri = new Uri("obex://" + device.DeviceAddress + "/" + file);
                var request = new ObexWebRequest(uri);
                request.ReadFile(file);
                var response = (ObexWebResponse)request.GetResponse();
                MessageBox.Show(response.StatusCode.ToString());
                // check response.StatusCode
                response.Close();
            }
