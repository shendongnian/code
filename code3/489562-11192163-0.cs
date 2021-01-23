    if (!_tc.Connected)
                {
                    try
                    {
                      
                        connect2(deviceIPAddress, devicePort);
                    }
                    catch
                    {
                        if (deviceDownNotified == false)
                        {
                            ((ListBox)mainUI.Controls["lbLog"]).InvokeEx(f => ((ListBox)mainUI.Controls["lbLog"]).Items.Add("device " + device.deviceDescription + " down at " + System.DateTime.Now));
                            (mainUI.Controls["btn" + device.deviceButtonNumber]).BackgroundImage = null;
                            (mainUI.Controls["btn" + device.deviceButtonNumber]).BackColor = Color.Blue;
                            deviceDownNotified = true;
                            try
                            {
                                _tc = new TcpClient();
                                initialPoll = false;
                                MessageBox.Show("here");
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message);
                            }
                        }
                    }
                }
