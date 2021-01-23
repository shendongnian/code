    //it seems 81920 is the default size in CopyTo but this can be changed
    public static void CopyTo(this Stream destination, int bufferSize = 81920)
    {
        byte[] array = new byte[bufferSize];
        int count;
        while ((count = destination.Read(array, 0, array.Length)) != 0)
        {
           destination.Write(array, 0, count);
        }
    }
