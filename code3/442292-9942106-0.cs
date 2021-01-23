    public enum ConfigSetupByte0Bitmap
    {
        Config5VReg(0x80),
        ConfigPMux(0x40); 
    
        public final int value;
        
        private ConfigSetupByte0Bitmap(final int value)
        {
            this.value = value;
        }
    }
    
    public void SetVReg(boolean val)
    {
        //vReg = val;
        if (val)
        {
            configSetupByte0 |= (int)ConfigSetupByte0Bitmap.Config5VReg.value;
        }
        else
        {
            configSetupByte0 &= ~(int)ConfigSetupByte0Bitmap.Config5VReg.value;   
        }
    }
