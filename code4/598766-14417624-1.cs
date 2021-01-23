        public void WriteDataPitch(IntPtr ptr, int len)
        {
            DataRectangle dr = this.Texture.LockRectangle(0, LockFlags.Discard);
            int pos = 0;
            int stride = this.Width * 4;
            byte* data = (byte*)ptr.ToPointer();
            for (int i = 0; i < this.Height; i++)
            {
                dr.Data.WriteRange((IntPtr)data, this.Width * 4);
                pos += dr.Pitch;
                dr.Data.Position = pos;
                data += stride;
            }
            this.Texture.UnlockRectangle(0);
        }
