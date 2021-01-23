    IFormatter formatter = new BinaryFormatter();
    Stream stream = new FileStream(op.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    FCnt = (int)formatter.Deserialize(stream);
    for (int i = 0; i < FCnt; i++)
    {
       facility[i] = (Facility)formatter.Deserialize(stream);
    }
    stream.Close();
