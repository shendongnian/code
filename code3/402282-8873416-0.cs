    foreach (System.Messaging.Message m in msgs)
    {
        byte[] bytes = new byte[m.BodyStream.Length];
        m.BodyStream.Read(bytes, 0, (int)m.BodyStream.Length);
        System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
        ParserClass tst = new ParserClass(ascii.GetString(bytes, 0, (int)m.BodyStream.Length));
        ThreadPool.QueueUserWorkItem(tst.ProcessXML);
    }
