    public int getDeviceType(string device)
    {
        int temp = 0;
        if (device.ToLower() == "android")
        {
            temp = 1;
        }
        else if (device.ToLower() == "ios")
        {
            temp = 2;
        }
        return temp;
    }
