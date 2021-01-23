    foreach (FTD2XX.FT_DEVICE_INFO_NODE node in arrInfoNodes)
    {
        if (node == null)
        {
            break;
        }
        else
        {
            if (fObject.OpenBySerialNumber(node.SerialNumber) ==
                Ftdi.FTD2XX.FT_STATUS.FT_OK)
            {
                fObject.GetCOMPort(out strPortName);
                fObject.Close();  // <<-- New Code here!
                listResult.Add(strPortName);
            }
        }
    }
