    function CallSilverlight() 
    {
      if(silverlightControl != null)
      {
        silverlightControl.Content.SilverlightScriptableObject.PerformRfidRead(); //**2**  
      }
    }
