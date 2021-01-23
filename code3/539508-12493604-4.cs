    List<int> offsets = new List<int>();
    for (int i = 0; i < num_pointers; i++)
    {
        // Note: There is no need to set the position in the stream as
        // the Read method will advance the stream to the next position
        // automatically.
        // br.BaseStream.Position = i * 4 + 4;
        offsets.Add(br.ReadInt32());
    }
