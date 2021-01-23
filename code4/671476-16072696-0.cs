        public void AddTexture(Bitmap texture, bool mipmaped)
        {
            this.tex_id = World.LoadTexture(texture, mipmaped);
        }
        public void AddText(string text, Color color, float x, float y, float scale)
        {
            const int side = 256;
            Bitmap texture = new Bitmap(side, side, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(texture);
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillRectangle(brush, new Rectangle(Point.Empty, texture.Size));
            }
            using (Font font = new Font(SystemFonts.DialogFont.FontFamily,  12f))
            {
                SizeF sz = g.MeasureString(text, font);
                float f = 256 / Math.Max(sz.Width, sz.Height) * scale;
                g.TranslateTransform(256 / 2 + f * sz.Width / 2, 256 / 2 - f * sz.Height / 2);
                g.ScaleTransform(-f, f);
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawString(text, font, brush, 0, 0);
                }
            }
            AddTexture(texture, true);
        }
        public static int LoadTexture(Bitmap texture, bool mipmaped)
        {
            int id = gl.GenTexture();
            gl.BindTexture(TextureTarget.Texture2D, id);
            int wt = texture.Width;
            int ht = texture.Height;
            gl.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            gl.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            System.Drawing.Imaging.BitmapData data = texture.LockBits(
                new Rectangle(0, 0, wt, ht),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            gl.TexImage2D(TextureTarget.Texture2D, 0,
                PixelInternalFormat.Rgba, wt, ht, 0,
                PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            texture.UnlockBits(data);
            if (mipmaped)
            {
                gl.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                gl.TexParameter(TextureTarget.Texture2D,
                    TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            }
            else
            {
                gl.TexParameter(TextureTarget.Texture2D,
                    TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            }
            gl.TexParameter(TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            return id;
        }
