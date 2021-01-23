    void Main()
    {
        enmBC_LIC_Version v = enmBC_LIC_Version.BC_LIC_LINEAR /*| enmBC_LIC_Version.BC_LIC_DATAM*/;
    	bool outp = QSBarcodeCheckLicenseVersionFunc(v);
    	Console.WriteLine(outp);
    }
    
    public bool QSBarcodeCheckLicenseVersionFunc(enmBC_LIC_Version eVersionToCheck)
    {
        enmBC_LIC_Version lLicense = enmBC_LIC_Version.BC_LIC_DATAM;
        return ((lLicense & eVersionToCheck) == lLicense);
    }
    
    // Define other methods and classes here
    [Flags]
    public enum enmBC_LIC_Version
    {
        BC_LIC_DEMO = 0x01,
        BC_LIC_LINEAR = 0x02,
        BC_LIC_PDF417 = 0x04,
        BC_LIC_DATAM = 0x08
    }
