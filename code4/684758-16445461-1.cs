    private void SynTP_Dev_OnPacket()
    {
        if (SynTP_Dev.LoadPacket(SynTP_Pack) == 1)
        {
            Console.WriteLine(SynTP_Pack.FingerState);
            Console.WriteLine(SynTP_Pack.X);
            Console.WriteLine(SynTP_Pack.Y);
        }
    }
