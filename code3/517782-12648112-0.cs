        // Using native memcpy for the fastest possible copy
        [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        private static extern IntPtr memcpy(IntPtr dest, IntPtr src, UIntPtr count);
        /// <summary>
        /// Copies a bitmap to gpu memory
        /// </summary>
        /// <param name="frame">The image to copy to the gpu</param>
        /// <returns>A texture in gpu memory for the bitmap</returns>
        public Texture2D CopyFrameToGpuMemory(Bitmap frame)
        {
            SampleDescription sampleDesc = new SampleDescription();
            sampleDesc.Count = 1;
            sampleDesc.Quality = 0;
            Texture2DDescription texDesc = new Texture2DDescription()
            {
                ArraySize = 1,
                MipLevels = 1,
                SampleDescription = sampleDesc,
                Format = Format.B8G8R8A8_UNorm,
                CpuAccessFlags = CpuAccessFlags.Write,
                BindFlags = BindFlags.ShaderResource,
                Usage = ResourceUsage.Dynamic,
                Height = frame.Height,
                Width = frame.Width
            };
            Texture2D tex = new Texture2D(Device, texDesc);
            Surface surface = tex.AsSurface();
            DataRectangle mappedRect = surface.Map(SlimDX.DXGI.MapFlags.Write | SlimDX.DXGI.MapFlags.Discard);
            BitmapData pixelData = frame.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            unsafe //!!!
            {
                byte* pixelDataStart = (byte*)pixelData.Scan0.ToPointer();
                byte* mappedRectDataStart = (byte*)mappedRect.Data.DataPointer.ToPointer();
                for (int y = 0; y < texDesc.Height; y++)
                {
                    byte* lineLocationDest = mappedRectDataStart + (y * mappedRect.Pitch);
                    byte* lineLocationSrc = pixelDataStart + (y * pixelData.Stride);
                    // Copy line by line for best performance
                    memcpy((IntPtr)lineLocationDest, (IntPtr)lineLocationSrc, (UIntPtr)(texDesc.Width * 4));
                }
            } //!!!
            frame.UnlockBits(pixelData);
            mappedRect.Data.Dispose();
            surface.Unmap();
            surface.Dispose();
            return tex;
        }
