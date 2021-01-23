    public override void TakePhoto(Random rnd)
    {
        int photo = rnd.Next(1, 10);
        for (int i = 0; i < MemoryCard.buffer.Length; i++)
        {
            MemoryCard.buffer[i] = photo;
        }
    }
