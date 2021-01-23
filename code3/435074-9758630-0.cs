    IEnumerable<uint> GetColors(byte[] rawImageBytes) 
    { 
        int lastTime        = Environment.TickCount;
        for (int i = 0; i < rawImageBytes.Length - 3; i += 3)
        {
            if (Environment.TickCount - lastTime > 10000)
            {
               setStatus(((i - lastCount)/10) + " checks per second");
               lastTime = Environment.TickCount;
               lastCount = i;
            }
    
    
            currentColor = (uint)((rawImageBytes[i] << 0) | (rawImageBytes[i + 1] << 8) | (rawImageBytes[i + 2] << 16));
    
            yield return currentColor; 
       }
    } 
