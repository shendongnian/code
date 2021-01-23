            var j = new Microsoft.Expression.Encoder.ScreenCapture.ScreenCaptureJob();
            j.OutputScreenCaptureFileName = @"C:\Users\Dominik\Desktop\test.wmv";
            //j.AddAudioDeviceSource(Microsoft.Expression.Encoder.Devices.EncoderDevices.FindDevices(Microsoft.Expression.Encoder.Devices.EncoderDeviceType.Audio);
            var audioDevices = Microsoft.Expression.Encoder.Devices.EncoderDevices.FindDevices(Microsoft.Expression.Encoder.Devices.EncoderDeviceType.Audio);
            var videoDevices = Microsoft.Expression.Encoder.Devices.EncoderDevices.FindDevices(Microsoft.Expression.Encoder.Devices.EncoderDeviceType.Video);
            j.AddAudioDeviceSource(audioDevices.ElementAt(1));
            j.Start();
