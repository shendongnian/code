    while (cursize < size) {
        DateTime start = DateTime.Now;
        byte[] buffer = new byte[4096];
        readblocks = fs.Read(buffer, 0, 4096);
        ServerConnector.send("r", getBase64FromBytes(buffer));
        DateTime end = DateTime.Now;
        Console.Writline((end-start).TotalSeconds);
        cursize = cursize + Convert.ToInt64(readblocks);
        ThreadInfos.wait.setvalue((csize / size) * 100);
        end = DateTime.Now;
        Console.Writline((end-start).TotalSeconds);
    }
