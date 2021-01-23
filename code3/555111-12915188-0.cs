    if( stm.CanRead && stm.DataAvailable )
    {
        int k = stm.Read(bb, 0, 100);
        for (int i = 0; i < k; i++)
            Console.Write(Convert.ToChar(bb[i]));               
    }
    tcpclnt.Close();
