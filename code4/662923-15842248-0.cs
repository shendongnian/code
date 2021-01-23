    catch (Exception ex)
                {
                    if ((uint)ex.HResult == 0x8007048F)
                    {
                        var result = MessageBox.Show("Bluetooth is turned off.\nTo see the current Bluetooth settings tap 'ok'", "Bluetooth Off", MessageBoxButton.OKCancel);
                        if (result == MessageBoxResult.OK)
                        {
                            ShowBluetoothcControlPanel();
                        }
                    }
                    else if ((uint)ex.HResult == 0x8007271D)
                    {
                        //0x80070005 - previous error code that may be wrong?
                        MessageBox.Show("To run this app, you must have ID_CAP_PROXIMITY enabled in WMAppManifest.xaml");
                    }
                    else if ((uint)ex.HResult == 0x80072740)
                    {
                        MessageBox.Show("The Bluetooth port is already in use.");
                    }
                    else if ((uint)ex.HResult == 0x8007274C)
                    {
                        MessageBox.Show("Could not connect to the selected Bluetooth Device.\nPlease make sure it is switched on.");
                    }
                    else
                    {
                        //App.handleException(ex);
                        MessageBox.Show(ex.Message);
                    }
                }
