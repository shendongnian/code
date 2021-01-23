    private void changeBackgroundImage()
    {
        //set the backgroundImage for this form
        this.BackgroundImage = new Bitmap(Properties.Resources._1334821694552, new Size(800, 500));
    
        //save the backgroundImage in an application settings
        Settings.Default["formBackgroundImage"] = "_1334821694552";
    
        //set the backgroundImage for all open forms in the application:
    	    foreach (Form f in Application.OpenForms) {
    	    	    f.BackgroundImage = new  Bitmap(Properties.Resources.ResourceManager.GetObject(Settings.Default["formBackgroundImage"]),new Size(800, 500));
    	    }
    
    } 
