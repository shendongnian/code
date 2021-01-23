    Formes.CameraViewVS frmCamera;
    
    public bool propertyZoomCam
    {
    	get 
    	{
    		if (frmCamera!=null)
    			return frmCamera.checkBoxZoomCam.Checked; 
    		else 
    			return false;
    	}
    }
    
    
    public void timer()
    {
      for (int l = 0; l < 2; l++)        
      {            
        cameraInstance[l].Start();
        if (cameraInstance[l].MoveDetection == true)
        {
          foreach (Form S in Application.OpenForms)
          {
            frmCamera = S as Formes.CameraViewVS;
            if (frmCamera != null && frmCamera.Addresse == cameraInstance[l].adresse) {
              // Match, activate it
              cameraInstance[l].MoveDetection = false;
              frmCamera.WindowState = FormWindowState.Normal;
              frmCamera.Activate();
              return;
            }
          }
          // No match found, create a new one
          frmCamera = new Formes.CameraViewVS(cameraInstance[l], adresseIPArray[l]);
          frmCamera.Show(this);
          if(propertyZoomCam)
            zoom = 15;
        }
      }
    }      
