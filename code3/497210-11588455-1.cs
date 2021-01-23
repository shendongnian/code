        camMedia.MediaSource = CameraIP;    
        camMedia.MediaUsername = UserName;  
        camMedia.MediaPassword = Password;    
        camMedia.HttpPort = HttpPort;//80    
        camMedia.RegisterPort = RegisterPort;//6000    
        camMedia.ControlPort = ControlPort;//6001    
        camMedia.StreamingPort = StreamingPort;//6002    
        camMedia.Connect(0);
