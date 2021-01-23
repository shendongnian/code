    public float[] GetData(this MyIndexer indexer)
    {
        float[] data = new float[indexer.GetSize];
        for(int i = 0; i < data.Length; i++)
        {
            data[i] = indexer[i];
        }
    }
