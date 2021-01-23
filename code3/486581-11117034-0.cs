    /// <summary>
    /// The current value of the control
    /// </summary>
    public bool Value 
    {
        get 
        {
            GetControlDetails(); // make sure we have the latest value
            return (boolDetails.fValue == 1);
        }
        set 
        {
            //GetControlDetails();
            //MixerInterop.MIXERCONTROLDETAILS_BOOLEAN boolDetails = (MixerInterop.MIXERCONTROLDETAILS_BOOLEAN) Marshal.PtrToStructure(mixerControlDetails.paDetails,typeof(MixerInterop.MIXERCONTROLDETAILS_BOOLEAN));
            //boolDetails.fValue = (value) ? 1 : 0;
            // TODO: pin the memory
            MmException.Try(MixerInterop.mixerSetControlDetails(mixerHandle, ref mixerControlDetails, MixerFlags.Value | mixerHandleType), "mixerSetControlDetails");
        }
    }	
