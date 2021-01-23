    for (int y = 0; y < bmpData.Height; ++y)
    { 
        byte* ptrSrc = (byte*)(bmpData.Scan0 + y * bmpData.Stride);
        int* pixelPtr = (int*)ptrSrc;
        for (int x = 0; x < bmpData.Width; ++x)
        {
            Color col = Color.FromArgb(*pixelPtr);
            
            if (col == ColorToFind) return new Point(x, y);
            ++pixelPtr; //Increate ptr by 4 bytes, because it is int
        }
    }
