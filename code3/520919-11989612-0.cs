    byte[] _data = new byte[]
    {
        255, 0, 0, 255,	// Blue
        0, 255, 0, 255,	// Green
        0, 0, 255, 255,	// Red
        0, 0, 0, 255,	// Black
    };
    var arrayHandle = System.Runtime.InteropServices.GCHandle.Alloc(_data,
            System.Runtime.InteropServices.GCHandleType.Pinned);
    var bmp = new Bitmap(2, 2, // 2x2 pixels
        8,                     // RGB32 => 8 bytes stride
        System.Drawing.Imaging.PixelFormat.Format32bppArgb,
        arrayHandle.AddrOfPinnedObject()
    );
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.BackgroundImage = bmp;
