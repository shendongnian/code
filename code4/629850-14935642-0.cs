    int stride = single0.Length; // Or multi.GetLength(1)
    Buffer.BlockCopy(single0, 0, multi, stride * 0, stride);
    Buffer.BlockCopy(single1, 0, multi, stride * 1, stride);
    Buffer.BlockCopy(single2, 0, multi, stride * 2, stride);
    Buffer.BlockCopy(single3, 0, multi, stride * 3, stride);
    Buffer.BlockCopy(single4, 0, multi, stride * 4, stride);
