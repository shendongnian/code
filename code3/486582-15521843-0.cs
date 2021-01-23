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
            int structSize = Marshal.SizeOf(boolDetails);
            mixerControlDetails.paDetails = Marshal.AllocHGlobal(structSize * nChannels);
            for (int channel = 0; channel < nChannels; channel++)
            {
                boolDetails.fValue = value ? 1 : 0;
                long pointer = mixerControlDetails.paDetails.ToInt64() + (structSize * channel);
                Marshal.StructureToPtr(boolDetails, (IntPtr)pointer, false);
            }
            MmException.Try(MixerInterop.mixerSetControlDetails(mixerHandle, ref mixerControlDetails, MixerFlags.Value | mixerHandleType), "mixerSetControlDetails");
            Marshal.FreeHGlobal(mixerControlDetails.paDetails);
        }
