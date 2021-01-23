        public void LoadTexture(string name, string path)
        {
            var bitmap = new Bitmap(path);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                             ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            int textureId;
            Gl.glGenTextures(1, out textureId);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA8, bitmap.Width, bitmap.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            _textureStorage.Add(name, new Texture(textureId, path, bitmap.Width, bitmap.Height));
            bitmap.UnlockBits(bitmapData);
            bitmap.Dispose();
        }
