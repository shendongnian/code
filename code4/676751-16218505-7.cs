    private void ReadMessage(object obj)
        {
            try
            {
                byte[] arr = null;
                TcpClient client = (TcpClient) obj;
                using (NetworkStream netstream = client.GetStream())
                {
                    using (BinaryReader br = new BinaryReader(netstream))
                    {
                        var arrLen = new byte[4];
                        br.Read(arrLen, 0, 4);
                        int len = BitConverter.ToInt32(arrLen, 0);
                        if (len > 0)
                        {
                            arr = new byte[len];
                            int read = 0;
                            while (read != len)
                            {
                                read += br.Read(arr, read, arr.Length - read);
                            }
                        }
                    }
                }
                if (arr != null && arr.Length > 0)
                {
                    try
                    {
                        Action act = delegate
                            {
                                MemoryStream strmImg = new MemoryStream(arr);
                                BitmapImage myBitmapImage = new BitmapImage();
                                myBitmapImage.BeginInit();
                                myBitmapImage.StreamSource = strmImg;
                                myBitmapImage.EndInit();
                                img1.Source = myBitmapImage;
                            };
                        this.Dispatcher.BeginInvoke(act);
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
                
                client.Close();
            }
            catch (Exception ex)
            {
            }
        }
