    string temp = String.Empty;
    if (DataBuffer != null) {
        temp = getLine(DataBuffer.Substring(mylocation));
    }
    if (!checkTypeFound())
    {
        if (!String.IsNullOrEmpty(temp))
        {
            parseDeviceType(temp);
        }
        checkTypeFound();
    }
