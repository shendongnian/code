    public EndpointVolumeEnforcer() {
      try {
        mmDeviceEnumerator = new MMDeviceEnumerator();
        mmDevice = mmDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
        audioEndpointVolume = mmDevice.AudioEndpointVolume;
        audioEndpointVolume.OnVolumeNotification += data => {
          VolumePercent = Convert.ToInt16(data.MasterVolume*100);
          DeviceIsMuted = data.Muted;
        };
        DesiredVolume = 65;
      }
      catch (Exception ex) {
        // Logging logic here
      }
    }
    public int DesiredVolume {
      get { return _desiredVolume; }
      private set {
        if (_desiredVolume == value) return;
        _desiredVolume = value;
        NotifyOfPropertyChange();
        Enforce(_desiredVolume);
      }
    }
    public int VolumePercent {
      get { return volumePercent; }
      private set {
        if (volumePercent == value) return;
        volumePercent = value;
        if (volumePercent != _desiredVolume) {
          volumePercent = _desiredVolume;
          Enforce(volumePercent);
        }
      }
    }
    public void Enforce(int pct, bool mute = false) {
      var adjusted = Convert.ToInt16(audioEndpointVolume.MasterVolumeLevelScalar*100);
      if (adjusted != DesiredVolume) {
        audioEndpointVolume.MasterVolumeLevelScalar = pct/100f;
      }
    }
