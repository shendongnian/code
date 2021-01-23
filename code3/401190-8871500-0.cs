    byte[] bytes = getImageBytes();
    Color[] colors = new Color[bytes.Length];  
    for(int i = 0; i < bytes.Length; i++)
    {
        colors[i] = Color.FromArgb(255, bytes[i], 0);
    }
