    class myForm
    {
    	private bool radioStatus = false; // depends on the default status of the radios
    	private bool RadioStatus 
    	{
    		get{return radioStatus;} set {radioStatus = value; Checked_Changed();}
    	}
    	
    	public myForm()
    	{
        // Lambdas as handlers to keep code short.
    	DoctorRadioButton.CheckedChanged += (s,args)=> 
            { if((s as RadioButton).Checked) RadioStatus = true; };
    	PatientRadioButton.CheckedChanged += (s,args)=> 
            { if((s as RadioButton).Checked) RadioStatus = false; };
    	}
    	
    	void Checked_Changed()
    	{
    		if (RadioStatus) // = true --> DoctorRadioButton was checked
    		{
    			//code
    		}
    		else // = false --> PatientRadioButton was checked
    		{
    			//other code
    		}
    	}
    }
