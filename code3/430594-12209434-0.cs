    protected override void Draw()
    {
        //Unset the texture from the GraphicsDevice
        for (int i = 0; i < 16; i++)
                {
                    if (Game.GraphicsDevice.Textures[i] == backTexture)
                    {
                        Game.GraphicsDevice.Textures[i] = null;
                        break;
                    }
                }
        backTexture.SetData<byte>(image.GetBytes());                
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
        // TODO: Add your drawing code here
        sprites.Begin();
        Vector2 pos = new Vector2(0, 0);
        sprites.Draw(backTexture, pos, Microsoft.Xna.Framework.Color.White);
        sprites.End();
    }
    public static byte[] GetBytes(this Bitmap bitmap)
    {
        var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 
            System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
        // calculate the byte size: for PixelFormat.Format32bppArgb (standard for GDI bitmaps) it's the hight * stride
        int bufferSize = data.Height * data.Stride; // stride already incorporates 4 bytes per pixel
        // create buffer
        byte[] bytes = new byte[bufferSize];
        // copy bitmap data into buffer
        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
        // unlock the bitmap data
        bitmap.UnlockBits(data);
        return bytes;
    }
