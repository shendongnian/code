    public System.Collections.ObjectModel.ObservableCollection<CtlStateBool> IsLightOnVal
    {
    	get
    	{
    		if ( m_IsLightOnVal == null )
    			this.SetValue(IsLightOnValProperty, m_IsLightOnVal = new System.Collections.ObjectModel.ObservableCollection<CtlStateBool>());
    		return m_IsLightOnVal;
    	}
    	set
    	{
    		if ( m_IsLightOnVal != value )
    		{
    			this.SetValue( IsLightOnValProperty, m_IsLightOnVal = value );
    			OnPropertyChanged( "IsLightOnVal" );
    		}
    	}
    }
