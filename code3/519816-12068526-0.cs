    private string Broadcast_Webcam()
        {
            if (_job == null)
            {
                v_Device = EncoderDevices.FindDevices(EncoderDeviceType.Video);
                a_Device = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
                _job = new LiveJob();
                _source = _job.AddDeviceSource(v_Device.Count > 0 ? v_Device[1] : null,                       a_Device.Count > 0 ? a_Device[0] : null);
                _job.ActivateSource(_source);
            }
            if (_job != null)
            {
                _job.ApplyPreset(LivePresets.VC1Broadband4x3);
                PullBroadcastPublishFormat format = new PullBroadcastPublishFormat();
                format.BroadcastPort = 8080;
                format.MaximumNumberOfConnections = 2;
                _job.PublishFormats.Add(format);
                _job.StartEncoding();
                
            }
            return "Webcam service has been started";
        }
