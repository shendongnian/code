        uint[] colors = new uint[rawImageBytes.Length / 3];
        Dictionary<uint,int> hits    = new Dictionary<uint,int>();
        int colorAmount     = 0;
        int totalRepeats    = 0;
        int lastTime        = Environment.TickCount;
        int lastCount       = 0;
        uint currentColor   = 0;
        
        for (int i = 0; i < rawImageBytes.Length - 3; i += 3)
        {
            if (Environment.TickCount - lastTime > 10000)
            {
                setStatus(((i - lastCount)/10) + " checks per second");
                lastTime = Environment.TickCount;
                lastCount = i;
            }
            currentColor = (uint)((rawImageBytes[i] << 0) | (rawImageBytes[i + 1] << 8) | (rawImageBytes[i + 2] << 16));
            
            if (hits.ContainsKey(currentColor))
            {
                hits[currentColor]++;
            }
            else
            {
                hits.Add(currentColor,1);
            }
        }
