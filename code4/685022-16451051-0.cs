    public bool CheckProperty(object myObjectToBeChecked, PropertyInfo p) 
    { 
        return p.GetValue(myObjectToBeChecked, null).Equals(PropertyCorrectValues[p]); 
    }
    public void DoCorrection(object myObjectToBeCorrected, PropertyInfo p) 
    { 
        p.SetValue(myObjectToBeCorrected, PropertyCorrectValues[p]); 
    }
   
