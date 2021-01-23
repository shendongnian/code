    public Controls MyReusableMethod (List<IMyReusableInterface> data) {
        int locationControl = 78;
    	var controls = new List<Control>();
    	
    	foreach (var x in data) {
            KPIEntrys uc = new KPIEntrys();         // UserControl
    
            uc.KPI = x.KPI;                         // Add data to properties
            uc.Status = x.Status.ToString();
            uc.Goal = x.Goal.ToString();
            uc.Currently = x.Currently.ToString();
            // I've simplefied the boolean checks.
    		uc.ShowAction = x.ShowAction;
    		uc.ShowStats = x.ShowStats;
    		uc.StatusGood = x.Status < x.StatusSignal;
            uc.Location = new Point(21, locationControl);
    		
            controls.Add(uc);                  // Add Control to Form
    
            locationControl = locationControl + 34;
        }
    	
    	return controls;
    }
