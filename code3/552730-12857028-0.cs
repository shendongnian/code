    public int GetCurentMilisecond()
    {
        String command = "status MediaFile position";
        error = mciSendString(command, returnData, 
                              returnData.Capacity, IntPtr.Zero);
        return error == 0 ? int.Parse(returnData.ToString()) : 0;
    }
    
    public int GetSongLenght()
    {
        if (IsPlaying())
        {
            String command = "status MediaFile length";
            error = mciSendString(command, returnData, returnData.Capacity, IntPtr.Zero);
            return error == 0 ? int.Parse(returnData.ToString()) : 0;
        }
        else
            return 0;
    }
