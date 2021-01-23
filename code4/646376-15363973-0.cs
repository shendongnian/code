    Public bool QSBarcodeCheckLicenseVersion(enmBC_LIC_Version eVersionToCheck)
    {
        int lLicense = 8;
        if (lLicense & eVersionToCheck)
            return true;
        else
            return false;
    }
    Public enum enmBC_LIC_Version
    {
        BC_LIC_DEMO = 1,
        BC_LIC_LINEAR = 2,
        BC_LIC_PDF417 = 4,
        BC_LIC_DATAM = 8
    }
