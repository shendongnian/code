    [ScaffoldColumn(false)]
    public string MyValueFormattedAsYYYYMMDD { get; set; }
    
    public string MyValueAsFormattedDate
    {
    	get
    	{				
            return MyClassToTransform.MyTransformMethod(this.MyValueFormattedAsYYYYMMDD);
    	}
    }
