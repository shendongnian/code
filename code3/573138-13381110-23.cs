     using (var videoFrame = e.OpenColorImageFrame())
                {
                    if (videoFrame != null)
                    {
                        var bits = new byte[videoFrame.PixelDataLength];
                        videoFrame.CopyPixelDataTo(bits);
                    }
                }
