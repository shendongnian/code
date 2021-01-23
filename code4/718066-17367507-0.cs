    public void Torch(bool on)
    {
    	if (!this.Context.PackageManager.HasSystemFeature(PackageManager.FeatureCameraFlash))
    	{
    		Android.Util.Log.Info("ZXING", "Flash not supported on this device");
    		return;
    	}
    
    	if (camera == null)
    	{
    		Android.Util.Log.Info("ZXING", "NULL Camera");
    		return;
    	}
    
    	var p = camera.GetParameters();
    	var supportedFlashModes = p.SupportedFlashModes;
    
    	if (supportedFlashModes == null)
    		supportedFlashModes = new List<string>();
    
    	var flashMode=  string.Empty;
    
    	if (on)
    	{
    		if (supportedFlashModes.Contains(Android.Hardware.Camera.Parameters.FlashModeTorch))
    			flashMode = Android.Hardware.Camera.Parameters.FlashModeTorch;
    		else if (supportedFlashModes.Contains(Android.Hardware.Camera.Parameters.FlashModeOn))
    			flashMode = Android.Hardware.Camera.Parameters.FlashModeOn;
    	}
    	else 
    	{
    		if ( supportedFlashModes.Contains(Android.Hardware.Camera.Parameters.FlashModeOff))
    			flashMode = Android.Hardware.Camera.Parameters.FlashModeOff;
    	}
    
    	if (!string.IsNullOrEmpty(flashMode))
    	{
    		p.FlashMode = flashMode;
    		camera.SetParameters(p);
    	}
    }
