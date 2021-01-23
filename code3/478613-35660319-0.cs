    using CoreAudioApi;
    
    public class SystemVolumeConfigurator
    {
            private readonly MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
            private readonly MMDevice _playbackDevice;
    
            public SystemVolumeConfigurator()
            {
                _playbackDevice = _deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            }
    
            public int GetVolume()
            {
                return (int)(_playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            }
    
            public void SetVolume(int volumeLevel)
            {
                if (volumeLevel < 0 || volumeLevel > 100)
                    throw new ArgumentException("Volume must be between 0 and 100!");
    
                _playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeLevel / 100.0f;
            }
    }
