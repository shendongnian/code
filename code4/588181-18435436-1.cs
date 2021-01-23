    IntPtr context = IntPtr.Zero;
    try
    {
        context = IHUAPI.CreateTagCacheContext();
        if (context != IntPtr.Zero)
        {
            int number = 0;
            ihuErrorCode result = IHUAPI.FetchTagCacheEx2(context, Connection.Handle, mask, ref number);
            if (result == ihuErrorCode.OK)
            {
                for (int i = 0; i < number; i++)
                {
                    StringBuilder text = new StringBuilder();
                    IHUAPI.GetStringTagPropertyByIndexEx2(context, i, ihuTagProperties.Tagname, text, 128);
                    Console.WriteLine("Tagname=" + text.ToString());
                }
            }
        }
    }
    finally
    {
        if (context != IntPtr.Zero)
        {
            IHUAPI.CloseTagCacheEx2(context);
        }
    }
