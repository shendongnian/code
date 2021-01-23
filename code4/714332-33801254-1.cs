    private void SetTorchMode(){   
       try {
         if (BackgroundHandler.Instance.IsBackTorchExist) {
            if (_videoTorchMode == VideoTorchMode.Off) {
               _videoRecordingDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.On);
               _videoTorchMode = VideoTorchMode.On;
             }
             else {
                _videoRecordingDevice.SetProperty(KnownCameraAudioVideoProperties.VideoTorchMode, VideoTorchMode.Off);
                _videoTorchMode = VideoTorchMode.Off;                                    
             }
          }
       }
       catch (Exception ex){ }
    }
