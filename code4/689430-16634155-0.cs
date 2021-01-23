    private void SubscribeForMessage()
            {
                Id = proximityDevice.SubscribeForMessage("WindowsMime", messageReceived);
            }
    private void messageReceived(ProximityDevice sender, ProximityMessage message)
    {
                var buffer = message.Data.ToArray();
                int mimesize = 0;
                //search first '\0' charactere
                for (mimesize = 0; mimesize < 256 && buffer[mimesize] != 0; ++mimesize)
                {
                };
    
                //extract mimetype
                var messageType = Encoding.UTF8.GetString(buffer, 0, mimesize);
    
                //convert data to string. This depends on mimetype value.
                var scanned_message = Encoding.UTF8.GetString(buffer, 256, buffer.Length - 256);
                       
                    Dispatcher.BeginInvoke(() =>
                        {
                            if (proximityDevice != null)
                            {
                                proximityDevice.StopSubscribingForMessage(Id);
                                locationdisplay.Text = scanned_message;
    
                            }
                        });
    }
    
    
    // For the code to work, I added 
    // using System.Runtime.InteropServices.WindowsRuntime;
    // for access to the ToArray() and AsBuffer() 
    // functions to Read/Write respectively.
