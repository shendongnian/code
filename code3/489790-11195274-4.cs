    private void ConvertBitmapToBytes(Bitmap[] BitmapArray)
    {
        byte[][] BitmapBytes = new byte[BitmapArray.Length][];
        for (int i = 0; i < BitmapArray.Length; i++)
        {
            BitmapBytes[i] = ImageToByte(BitmapArray[i]);
        }
    }
