    static void barreader_method()
    {
        barreader.OpenPort(barport, 19200);
        byte TagType;
        byte[] TagSerial = new byte[4];
        byte ReturnCode = 0;
        string bartagno;
        List<Tuple<DateTime, String>> previoustags = new List<Tuple<DateTime, String>>();
        DateTime lastreaddt = DateTime.MinValue;
        while (true)
        {
            bartagno = "";
            while (!barreader.CMD_SelectTag(out TagType, out TagSerial, out ReturnCode))
            {
            }
            for (int i = 0; i < 4; i++)
            {
                bartagno += TagSerial[i].ToString("X2");
            }
            if (DateTime.Now - lastreaddt > TimeSpan.FromMinutes(1))
            {
                previoustags.Clear();
                barprocess(bartagno);
                previoustags.Add(Tuple.Create(DateTime.Now, bartagno));
                lastreaddt = DateTime.Now;
            }
            else
            {
                if (!previoustags.Exists(a => a.Item2.Equals(bartagno)))
                {
                    barprocess(bartagno);
                    previoustags.Add(Tuple.Create(DateTime.Now, bartagno));
                    lastreaddt = DateTime.Now;
                }
            }
            previoustags.RemoveAll(a => a.Item1.CompareTo(DateTime.Now - TimeSpan.FromMinutes(1)) < 0);
            Thread.Sleep(1200);
        }
    }
