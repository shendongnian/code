    var result = new Bitmap((int)info.width,(int)info.height,PixelFormat.Format24bppRgb);
    var data = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
    int y, ptr = data.Scan0.ToInt32();
    int[] lines = new int[result.Height];
    for (y = 0; y < lines.Length; y++)
    {
        lines[y] = ptr;
        ptr += data.Stride;
    }
    bool success = ReadFullImage(lines, ref info, ref png);
    result.UnlockBits(data);
    if (!success)
        return null;
    else
    {
        return result;
    }
