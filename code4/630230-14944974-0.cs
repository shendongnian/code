            while(isDisplayActive)
            {
                using (var frame = kinectSensor.ColorStream.OpenNextFrame(500))
                {
                    if (frame == null) continue;
                    if (displayDepthStream) continue;
                    Dispatcher.Invoke(new Action(() => colorManager.Update(frame)));
                }
            }
