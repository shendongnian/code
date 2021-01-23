    private static void FillSamples(object dataType, MyObject theSamples)
    {
    	Type t = dataType.GetType();
    	var px = t.GetProperty("SampleLength");
    	var py = t.GetProperty("SampleValue");
    	
    	for (int i = 0; i < sampleCount; i++)
    	{
    		px.SetValue(dataType, MyObject.X[i], null);
    		py.SetValue(dataType, MyObject.Y[i], null);
    	}
    }
